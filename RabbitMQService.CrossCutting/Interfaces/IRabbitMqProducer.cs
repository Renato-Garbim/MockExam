using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService.CrossCutting.Interfaces
{
    public interface IRabbitMqProducer<in T>
    {
        void Publish(T @event);
    }
}
