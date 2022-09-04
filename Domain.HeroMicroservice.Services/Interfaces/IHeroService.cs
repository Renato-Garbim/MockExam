using Domain.Utilities.CrossCutting;
using Dominio.HeroMicroservice.Entities;
using MockApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.HeroMicroservice.Services.Interfaces
{
    public interface IHeroService : IServiceBase<Hero, HeroDTO>
    {
    }
}
