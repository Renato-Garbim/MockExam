using RabbitMQService.CrossCutting.EventsModel;
using RabbitMQService.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackForFrontAngular.RCPMockTest
{
    public class LogBackgroundTask : BackgroundService
    {
        private readonly IRabbitMqProducer<LogIntegrationEvent> _producer;

        public LogBackgroundTask(IRabbitMqProducer<LogIntegrationEvent> producer) => _producer = producer;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
