using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BackForFrontAngular.Message
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;


        private ConcurrentDictionary<string, TaskCompletionSource<string>> _pendingMessages = new ConcurrentDictionary<string, TaskCompletionSource<string>>();

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


            consumer.Received += Consumer_Received;

            _channel.BasicConsume(
                consumer: consumer,
                queue: replyQueueName,
                autoAck: true);

        }

        private async Task Consumer_Received(object? sender, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            if (_pendingMessages.TryRemove(args.BasicProperties.CorrelationId, out var taskCompletionSource))
            {
                taskCompletionSource.SetResult(message);
            }
        }

        public Task<string> SendMessageExchange<T>(T message)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            _channel.BasicPublish(exchange: "hero_logs",
                                     routingKey: "binding_key_hero",
                                     basicProperties: props, body: body);

            _pendingMessages.TryAdd(props.CorrelationId, taskCompletionSource);

            return taskCompletionSource.Task;
            
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
