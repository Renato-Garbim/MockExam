using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAppServiceBase<TEntity, TEntityViewModel> where TEntity : class where TEntityViewModel : class
    {
        //TEntity MapperViewModelParaEntity(TEntityViewModel obj);

        bool AdicionarOuAtualizar(TEntityViewModel obj);
        bool Remover(int registroId);
        bool Remover(Guid registroId);

        TEntityViewModel ObterPorId(int registroId);
        IEnumerable<TEntityViewModel> ObterTodos();
        int TotalDeRegistros();
    }
}
