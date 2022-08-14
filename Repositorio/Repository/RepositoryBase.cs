﻿using Microsoft.AspNetCore.SignalR;
using HerosHandles.Interfaces.SignalR;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositorio.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly HeroAngularContext Db;
        protected readonly DbSet<TEntity> DBSet;
        private readonly INotifyService _notifyService;

        private readonly string _strConexao;

        public RepositoryBase(HeroAngularContext db, INotifyService notifyService)
        {
            Db = db;
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            DBSet = Db.Set<TEntity>();

            _notifyService = notifyService;
            _strConexao = Db.Database.GetDbConnection().ConnectionString;

        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        private void AlterarBanco()
        {
            Db.SaveChanges();
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
                AlterarBanco();

                inseridoSucesso = true;

            }
            catch (DbUpdateException /* ex */)
            {
                inseridoSucesso = false;
            }

            _notifyService.Enviar("Novo Registro Adicionado ao Banco.");

            return inseridoSucesso;
        }

        public virtual bool UpdateRecord(TEntity obj)
        {
            var updateSucesso = false;

            try
            {
                DBSet.Update(obj);
                AlterarBanco();

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
                AlterarBanco();

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
