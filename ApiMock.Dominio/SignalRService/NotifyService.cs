using ApiMock.Dominio.Hubs;
using ApiMock.Dominio.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMock.Dominio.SignalRService
{
    public class NotifyService : INotifyService
    {
        private IHubContext<CRUDHub> _hubContext;

        public NotifyService(IHubContext<CRUDHub> hubContext)
        {
            _hubContext = hubContext;
        }


    }
}
