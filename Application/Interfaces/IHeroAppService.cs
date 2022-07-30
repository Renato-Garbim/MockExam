using MockApi.Dominio.Entidades;
using MockApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IHeroAppService : IAppServiceBase<Hero, HeroDTO>
    {

    }
}
