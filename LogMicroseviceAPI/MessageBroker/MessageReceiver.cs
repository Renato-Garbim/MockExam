using AutoMapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RequestLog.Services.Interfaces;
using RequestLog.Services.Models;
using System.Text;
using System.Threading.Channels;
using WebAPIMock.Requests;

namespace LogMicroseviceAPI.MessageBroker
{
    public class MessageReceiver : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private readonly IProcessoRequisicao _processoRequisicao;
        private readonly string _queueName;

        public MessageReceiver(IConfiguration configuration, IProcessoRequisicao processoRequisicao)
        {
            _processoRequisicao = processoRequisicao;
            _configuration = configuration;
            var factory = new ConnectionFactory { HostName = _configuration["RabbitMQHost"], Port = Int32.Parse(_configuration["RabbitMQPort"]) };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "hero_logs", type: "topic");
            _queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: _queueName,
                                      exchange: "hero_logs",
                                      routingKey: "binding_key_hero");

            // _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            _consumer = new EventingBasicConsumer(_channel);


        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Received += (model, eventArgs) =>
            {
                string response = null;

                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var props = eventArgs.BasicProperties;
                var replyProps = _channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {                    
                    _processoRequisicao.ProcessaLogRequest(message);
                    response = "1";

                }
                catch (Exception e)
                {
                    Console.WriteLine(" [.] " + e.Message);
                    response = "0";
                }
                finally
                {
                    var responseBytes = Encoding.UTF8.GetBytes(response);

                    _channel.BasicPublish(exchange: "", routingKey: props.ReplyTo,
                      basicProperties: replyProps, body: responseBytes);

                    _channel.BasicAck(deliveryTag: eventArgs.DeliveryTag,
                      multiple: false);
                }
            };

            _channel.BasicConsume(queue: _queueName,autoAck: false, consumer: _consumer);

            return Task.CompletedTask;
        }
    }
}
