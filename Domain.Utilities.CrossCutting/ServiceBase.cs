
using AutoMapper;
using Domain.Utilities.Framework.Delegates;
using Domain.Utilities.Framework.Interface;
using FluentValidation.Results;
using Repository.Utilities.Framework.Interfaces;

namespace Domain.Utilities.Framework
{
    public class ServiceBase<TEntity, TEntityDTO> : IServiceBase<TEntity, TEntityDTO> where TEntity : class where TEntityDTO : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        protected readonly IMapper Mapper;
       
        public event CanBeChangedAtDataBase<TEntity> RegisterIsValidToBeChanged;

        public ServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            Mapper = mapper;
        }

        public bool InsertRecord(TEntityDTO objeto)
        {
            //todo: refatorar o código para isolar o invoke

            var entity = Mapper.Map<TEntity>(objeto);
            var result = false;

            ValidationResult objectToValidationSaveResult = GetObjectToValidationSaveResult(entity);

            if (objectToValidationSaveResult == null)
            {
                result = _repository.InsertRecord(entity);
                _repository.CommitAsync();
                return result;
            }

            if (!IsValidToSave(objectToValidationSaveResult))
            {
                return false;
            }

            result = _repository.InsertRecord(entity);
            _repository.CommitAsync();

            return result;
        }

        public bool UpdateRecord(TEntityDTO objeto)
        {
            var entity = Mapper.Map<TEntity>(objeto);

            return _repository.UpdateRecord(entity);

        }

        public IEnumerable<TEntityDTO> GetAllRecords()
        {
            var baseRegistries = _repository.GetAllRecords();

            return Mapper.Map<IEnumerable<TEntityDTO>>(baseRegistries);

        }

        public TEntityDTO GetRecordById(int id)
        {
            var register = _repository.GetRecordById(id);

            return Mapper.Map<TEntityDTO>(register);
        }

        public bool RemoveRecord(TEntityDTO objeto)
        {
            var entity = Mapper.Map<TEntity>(objeto);

            return _repository.RemoveRecord(entity);
        }

        public Task CommitAsync()
        {
            return _repository.CommitAsync();
        }

        public void Rollback()
        {
            _repository.Rollback();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public virtual ValidationResult? GetObjectToValidationSaveResult(TEntity obj)
        {
            return RegisterIsValidToBeChanged?.Invoke(obj);
        }

        private static bool IsValidToSave(ValidationResult validation)
        {
            if (validation.IsValid)
            {
                return true;
            }

            return false;
        }



    }

}
