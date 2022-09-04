﻿using HerosHandles.Interfaces.SignalR;
using HerosHandles.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HeroMicroservice.CrossCutting.IOC.Modules
{
    public class HandleModule
    {
        public static void SetModules(IServiceCollection container)
        {

            container.AddScoped<INotifyService, NotifyService>();


        }
    }
}
