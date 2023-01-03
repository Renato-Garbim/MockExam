using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Channels;

namespace BackForFrontAngular.Message
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;
        private readonly BlockingCollection<string> respQueue = new BlockingCollection<string>();
        private readonly IBasicProperties props;

        public MessageProducer(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory { HostName = _configuration["RabbitMQHost"], Port = Int32.Parse(_configuration["RabbitMQPort"]), DispatchConsumersAsync = true };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            string replyQueueName = _channel.QueueDeclare().QueueName;
            var consumer = new AsyncEventingBasicConsumer(_channel);

            _channel.ExchangeDeclare(exchange: "hero_logs",
                        type: "topic");

            props = _channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;


            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);
                if (ea.BasicProperties.CorrelationId == correlationId)
                {
                    respQueue.Add(response);
                    await Task.Yield();
                }
            };

            _channel.BasicConsume(
                consumer: consumer,
                queue: replyQueueName,
                autoAck: true);

        }

        public BlockingCollection<string> SendMessageExchange<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            _channel.BasicPublish(exchange: "hero_logs",
                                     routingKey: "binding_key_hero",
                                     basicProperties: props, body: body);

            return respQueue;
        }

        public void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            //Setando a msg para nao expirar 
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "", routingKey: "Hero_Service", body: body);            
        }
    }
}
