using HerosHandles.Interfaces.SignalR;
using HerosHandles.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMock.CrossCutting.IOC.Modules
{
    public class HandleModule
    {
        public static void SetModules(IServiceCollection container)
        {

            container.AddScoped<INotifyService, NotifyService>();


        }
    }
}
