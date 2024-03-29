﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MediatR;
using RabbitMQService.CrossCutting.Base;
using RabbitMQService.CrossCutting.EventsModel;

namespace RabbitMQService.CrossCutting.Consumers
{
    public class LogConsumer : ConsumerBase, IHostedService
    {
        protected override string QueueName => "CUSTOM_HOST.log.message";

        public LogConsumer( IMediator mediator, ConnectionFactory connectionFactory, ILogger<LogConsumer> logConsumerLogger, ILogger<ConsumerBase> consumerLogger, ILogger<RabbitMQBaseClass> logger) :
            base(mediator, connectionFactory, consumerLogger, logger)

        {
            try
            {
                var consumer = new AsyncEventingBasicConsumer(Channel);
                consumer.Received += OnEventReceived<LogCommand>;
                Channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            }
            catch (Exception ex)
            {
                logConsumerLogger.LogCritical(ex, "Error while consuming message");
            }
        }

        public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}
