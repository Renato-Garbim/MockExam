using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosHandles.Interfaces.SignalR
{
    public  interface INotifyService
    {
        void Enviar(string msg);
    }
}
