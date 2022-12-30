using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.CrossCutting.Base
{
    public abstract class ConsumerBase : RabbitMQBaseClass
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConsumerBase> _logger;
        protected abstract string QueueName { get; }

        protected ConsumerBase(IMediator mediator, ConnectionFactory connectionFactory, ILogger<ConsumerBase> consumerLogger, ILogger<RabbitMQBaseClass> logger) : base(connectionFactory, logger)
        {
            _mediator = mediator;
            _logger = consumerLogger;
        }

        protected virtual async Task OnEventReceived<T>(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var body = Encoding.UTF8.GetString(@event.Body.ToArray());
                var message = JsonConvert.DeserializeObject<T>(body);

                await _mediator.Send(message);

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error while retrieving message from queue.");
            }
            finally
            {
                Channel.BasicAck(@event.DeliveryTag, false);
            }
        }
    }
}
