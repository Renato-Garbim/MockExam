using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Channels;

namespace WebAPIMock.Message
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

            _channel.QueueDeclare(queue: "Notifications_Service",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
        }

        public void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            //Setando a msg para nao expirar 
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "", routingKey: "Notifications_Service", body: body);
        }
    }
}
