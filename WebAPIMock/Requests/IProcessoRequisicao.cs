﻿using System.Threading.Tasks;

namespace WebAPIMock.Requests
{
    public interface IProcessoRequisicao
    {
        Task ProcessaHeroRequest(string mensagemParaConsumir);
    }
}
