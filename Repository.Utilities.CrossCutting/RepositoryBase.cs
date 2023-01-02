using InfraMiggration;
using Microsoft.EntityFrameworkCore;
using Repository.Utilities.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Utilities.Framework
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Db { get; private set; }

        protected readonly DbSet<TEntity> DBSet;

        // for future implementation of a dapper 
        private readonly string _strConexao;

        public RepositoryBase(DbContext db)
        {
            Db = db;
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            DBSet = Db.Set<TEntity>();
            _strConexao = Db.Database.GetDbConnection().ConnectionString;            
        }

        public virtual IQueryable<TEntity> GetAllRecords()
        {
            var registros = DBSet.AsNoTracking().AsQueryable();
            return registros;
        }

        public virtual bool InsertRecord(TEntity obj)
        {
            var inseridoSucesso = false;

            try
            {
                DBSet.Add(obj);

                inseridoSucesso = true;

            }
            catch (DbUpdateException /* ex */)
            {
                inseridoSucesso = false;
            }

            return inseridoSucesso;
        }

        public virtual bool UpdateRecord(TEntity obj)
        {
            var updateSucesso = false;

            try
            {
                DBSet.Update(obj);
                updateSucesso = true;
            }
            catch (DbUpdateException /* ex */)
            {
                updateSucesso = false;
            }



            return updateSucesso;
        }

        public virtual bool RemoveRecord(TEntity obj)
        {

            var removidoSucesso = false;

            try
            {
                DBSet.Remove(obj);

                removidoSucesso = true;
            }
            catch (DbUpdateException /* ex */)
            {
                removidoSucesso = false;
            }

            return removidoSucesso;
        }

        public virtual TEntity GetRecordById(int id)
        {
            var registro = DBSet.Find(id);

            return registro;
        }

        public Task CommitAsync()
        {
            return Db.SaveChangesAsync();
        }

        public void Rollback()
        {
            //Db.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
        }



        //public virtual TEntity GetRecordById(Guid id)
        //{
        //    var guid = id.ToString();

        //    var propertyInfo = typeof(TEntity).GetProperty(typeof(TEntity).Name + "Guid");

        //    Expression<Func<TEntity, bool>> func = x => propertyInfo.GetValue("") == guid;

        //    //todo: necessário estudar o código de expression funcs e a biblioteca do DynamicLinq para conseguir utilizar o generics.

        //    var registro = DBSet.FirstOrDefault(func);

        //    return registro;
        //}

    }
}
