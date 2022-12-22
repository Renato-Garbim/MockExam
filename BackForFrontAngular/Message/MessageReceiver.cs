using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Channels;
using System.Text;

namespace BackForFrontAngular.Message
{
    public class MessageReceiver : IMessageReceiver
    {
        private readonly IConfiguration _configuration;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;

        public MessageReceiver(IConfiguration configuration)
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

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            _consumer = new EventingBasicConsumer(_channel);            
        }

        public string CheckQueu()
        {
            string notificationMessage = "";

            _consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);


                _channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);

                notificationMessage = message;
            };

            _channel.BasicConsume(queue: "Notifications_Service", autoAck: false, consumer: _consumer);

            return notificationMessage;
        }
    }
}
