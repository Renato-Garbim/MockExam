using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace BackForFrontAngular.Message
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;

        public MessageProducer(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory { HostName = _configuration["RabbitMQHost"], Port = Int32.Parse(_configuration["RabbitMQPort"]) };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "hero_logs",
                        type: "topic");

            //_channel.QueueDeclare(queue: "Hero_Service",
            //                  durable: true,
            //                  exclusive: false,
            //                  autoDelete: false,
            //                  arguments: null);            
        }

        public void SendMessageExchange<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            //criar o outro Binding para o Microservicehero

            _channel.BasicPublish(exchange: "hero_logs",
                                     routingKey: "binding_key_microservice_hero",
                                     basicProperties: null, body: body);

            _channel.BasicPublish(exchange: "hero_logs",
                                     routingKey: "binding_key_microservice_logRequest",
                                     basicProperties: null, body: body);
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
