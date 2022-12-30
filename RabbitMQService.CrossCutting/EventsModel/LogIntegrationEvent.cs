using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.CrossCutting.EventsModel
{
    public class LogIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
