using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace BackForFrontAngular.Message
{
    public class MessageProducer : IMessageProducer
    {
        readonly IModel _channel;

        public MessageProducer()
        {
            var factory = new ConnectionFactory { HostName = "" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare("register");
            //_channel.QueueDeclare("notifications");
        }

        public void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "", routingKey: "orders", body: body);            
        }
    }
}
