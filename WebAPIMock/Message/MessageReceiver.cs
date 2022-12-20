using Domain.HeroMicroservice.Services.Interfaces;
using HeroMicroservice.DTO;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIMock.Message
{
    public class MessageReceiver : BackgroundService
    {
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly IHeroService _heroService;

        public MessageReceiver()
        {
            var factory = new ConnectionFactory { HostName = "" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare("hero");
            _channel.QueueDeclare("notifications");
            _consumer = new EventingBasicConsumer(_channel);


        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            _consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);                

                var entityDTO = JsonConvert.DeserializeObject<HeroDTO>(message);

                bool result = _heroService.InsertRecord(entityDTO);

                //Todo: Instanciar o método para disparar as Notifications 

                //_channel.BasicPublish(exchange: "", routingKey: "orders", body: body);

            };

            _channel.BasicConsume(queue: "orders", autoAck: true, consumer: _consumer);

            return Task.CompletedTask;
        }



    }
}
