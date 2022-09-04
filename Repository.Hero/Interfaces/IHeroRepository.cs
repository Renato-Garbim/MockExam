using Dominio.HeroMicroservice.Entities;
using Repository.Utilities.CrossCutting.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.HeroMicroservice
{
    public interface IHeroRepository : IRepositoryBase<Hero>
    {

    }
}
