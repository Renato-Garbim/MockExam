using AutoMapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RequestLog.Services.Interfaces;
using RequestLog.Services.Models;
using System.Text;
using System.Threading.Channels;

namespace LogMicroseviceAPI.MessageBroker
{
    public class MessageReceiver : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly IHeroLogService _heroLogservice;
        protected readonly IMapper Mapper;
        private readonly string _queueName;

        public MessageReceiver(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory { HostName = _configuration["RabbitMQHost"], Port = Int32.Parse(_configuration["RabbitMQPort"]) };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "hero_logs", type: "topic");
            _queueName = _channel.QueueDeclare().QueueName;


            _channel.QueueBind(queue: _queueName,
                                      exchange: "hero_logs",
                                      routingKey: "binding_key_microservice_logRequest");
            
            //_channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            _consumer = new EventingBasicConsumer(_channel);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                //Salvar msgRequestLog no banco de dados
                var dto = Mapper.Map<HeroLogDTO>(message);

                _heroLogservice.InsertRecord(dto);

                _channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);

            };

            _channel.BasicConsume(queue: _queueName,autoAck: false, consumer: _consumer);

            return Task.CompletedTask;
        }
    }
}
