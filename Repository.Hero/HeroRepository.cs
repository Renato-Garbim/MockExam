using Dominio.HeroMicroservice.Entities;
using Repositorio;
using Repository.Utilities.CrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.HeroMicroservice
{
    public class HeroRepository : RepositoryBase<Hero>, IHeroRepository
    {
        public HeroRepository(HeroAngularContext db) : base (db)
        {

        }
    }
}
