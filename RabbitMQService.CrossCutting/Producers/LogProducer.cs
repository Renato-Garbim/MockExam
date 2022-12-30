using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQService.CrossCutting.Base;
using RabbitMQService.CrossCutting.EventsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.CrossCutting.Producers
{
    public class LogProducer : ProducerBase<LogIntegrationEvent>
    {
        public LogProducer(ConnectionFactory connectionFactory, ILogger<RabbitMQBaseClass> logger, ILogger<ProducerBase<LogIntegrationEvent>> producerBaseLogger) : base(connectionFactory, logger, producerBaseLogger)
        {

        }

        protected override string ExchangeName => "CUSTOM_HOST.LoggerExchange";
        protected override string RoutingKeyName => "log.message";
        protected override string AppId => "LogProducer";
    }
}
