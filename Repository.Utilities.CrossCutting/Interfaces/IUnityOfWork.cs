using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utilities.Framework.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        Task CommitAsync();
        void Rollback();
    }
}
