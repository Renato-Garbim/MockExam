using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.HeroMicroservice.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IHeroRepository Hero { get; }
        Task CommitAsync();
    }
}
