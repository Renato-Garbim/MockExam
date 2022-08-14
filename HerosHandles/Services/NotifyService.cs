using HerosHandles.Hubs;
using HerosHandles.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosHandles.Services
{
    public class NotifyService : INotifyService
    {
        private IHubContext<CRUDHub> _hubContext;

        public NotifyService(IHubContext<CRUDHub> hubContext)
        {
            _hubContext = hubContext;
        }


        public void Enviar(string msg)
        {
           _hubContext.Clients.All.SendAsync("Send", msg);
        }


    }
}
