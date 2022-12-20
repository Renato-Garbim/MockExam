using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Channels;
using System.Text;

namespace BackForFrontAngular.Message
{
    public class MessageReceiver : IMessageReceiver
    {

        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;

        public MessageReceiver()
        {
            var factory = new ConnectionFactory { HostName = "" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare("notifications");
            _consumer = new EventingBasicConsumer(_channel);
        }

        public string CheckQueu()
        {
            string notificationMessage = "";

            _consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);                                
                
                notificationMessage = message;
            };

            _channel.BasicConsume(queue: "notifications", autoAck: true, consumer: _consumer);

            return notificationMessage;
        }
    }
}
