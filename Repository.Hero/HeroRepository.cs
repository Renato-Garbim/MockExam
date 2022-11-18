using Dominio.HeroMicroservice.Entities;
using InfraMiggration;
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
