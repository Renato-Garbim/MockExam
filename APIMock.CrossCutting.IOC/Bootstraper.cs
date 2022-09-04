﻿using APIMock.CrossCutting.IOC.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIMock.CrossCutting.IOC
{
    public class Bootstraper
    {
        public static void RegisterServices(IServiceCollection container)
        {
            HandleModule.SetModules(container);
            RepositoryModule.SetModules(container);
            ServiceModule.SetModules(container);

        }
    }
}
