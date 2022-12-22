using Domain.HeroMicroservice.Services.Interfaces;
using HeroMicroservice.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPIMock.Requests;

namespace WebAPIMock.Message
{
    public class MessageReceiver : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly IProcessoRequisicao _processoRequisicao;

        public MessageReceiver(IConfiguration configuration, IProcessoRequisicao processoRequisicao)
        {
            _processoRequisicao = processoRequisicao;
            _configuration = configuration;
            var factory = new ConnectionFactory { HostName = _configuration["RabbitMQHost"], Port = Int32.Parse(_configuration["RabbitMQPort"]) };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "Hero_Service",
                              durable: true,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            _consumer = new EventingBasicConsumer(_channel);


        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            _consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                
                _processoRequisicao.ProcessaHeroRequest(message);

                _channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);

            };

            _channel.BasicConsume(queue: "Hero_Service", autoAck: false, consumer: _consumer);

            return Task.CompletedTask;
        }



    }
}
