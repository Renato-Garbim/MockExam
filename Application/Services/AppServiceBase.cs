using ApiMock.Dominio.Interfaces;
using Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class AppServiceBase<TEntity, TEntityDTO> : IAppServiceBase<TEntity, TEntityDTO> where TEntity : class where TEntityDTO : class
    {
        private readonly IServiceBase<TEntity> _cashbackServiceBase;
        protected readonly IMapper Mapper;

        protected AppServiceBase(IServiceBase<TEntity> cashbackServiceBase, IMapper mapper)
        {
            _cashbackServiceBase = cashbackServiceBase;
            Mapper = mapper;
        }

        public virtual bool AdicionarOuAtualizar(TEntityDTO obj)
        {
            var entity =  Mapper.Map<TEntity>(obj);

            var propertyInfo = typeof(TEntity).GetProperty(typeof(TEntity).Name + "Id");
            if (propertyInfo != null)
            {
                var atualizaRegistro = propertyInfo.PropertyType == typeof(Guid) ? VerificarRegistroParaAtualizacaoChaveGuid(propertyInfo.GetValue(entity).ToString()) :
                    VerificarRegistroParaAtualizacaoChaveInt(propertyInfo.GetValue(entity).ToString());

                if (atualizaRegistro)
                    return _cashbackServiceBase.UpdateRecord(entity);
            }
            entity = DefinirRegistroId(entity);
            return _cashbackServiceBase.InsertRecord(entity);
        }

        private static TEntity DefinirRegistroId(TEntity obj)
        {
            var propertyInfo = obj.GetType().GetProperty(typeof(TEntity).Name + "Id");

            if (propertyInfo != null && propertyInfo.PropertyType == typeof(Guid))
                propertyInfo.SetValue(obj, Convert.ChangeType(Guid.NewGuid(), propertyInfo.PropertyType), null);

            return obj;
        }
        private static bool VerificarRegistroParaAtualizacaoChaveGuid(string value)
        {
            var id = Guid.Parse(value);

            return (id != Guid.Empty);
        }

        private static bool VerificarRegistroParaAtualizacaoChaveInt(string value)
        {
            var id = int.Parse(value);
            return id > 0;
        }

        public bool Remover(int registroId)
        {
            var registro = _cashbackServiceBase.GetRecordById(registroId);
            return _cashbackServiceBase.RemoveRecord(registro);
        }

        public bool Remover(Guid registroId)
        {
            throw new NotImplementedException();
        }

        public TEntityDTO ObterPorId(int registroId)
        {
            var registro = _cashbackServiceBase.GetRecordById(registroId);
            return Mapper.Map<TEntityDTO>(registro);
        }

        public IEnumerable<TEntityDTO> ObterTodos()
        {
            var registros = _cashbackServiceBase.GetAllRecords();

            return Mapper.Map<IEnumerable<TEntityDTO>>(registros.ToList());
        }

        public int TotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
