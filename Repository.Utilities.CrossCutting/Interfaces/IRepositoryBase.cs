using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Utilities.Framework.Interfaces
{
    public interface IRepositoryBase<TEntity> : IUnityOfWork where TEntity : class
    {
        IQueryable<TEntity> GetAllRecords();
        bool InsertRecord(TEntity obj);
        bool UpdateRecord(TEntity obj);
        bool RemoveRecord(TEntity obj);
        TEntity GetRecordById(int id);
        //TEntity GetRecordById(Guid id);
    }
}
