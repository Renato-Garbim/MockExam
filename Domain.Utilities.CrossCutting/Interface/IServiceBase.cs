using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Utilities.Framework.Interface
{
    public interface IServiceBase<TEntity, TEntityDTO> where TEntity : class where TEntityDTO : class
    {
        bool InsertRecord(TEntityDTO objeto);
        bool UpdateRecord(TEntityDTO objeto);
        IEnumerable<TEntityDTO> GetAllRecords();
        TEntityDTO GetRecordById(int id);
        bool RemoveRecord(TEntityDTO registro);
        Task CommitAsync();
        void Rollback();
        void Dispose();
    }
}
