
using Dominio.HeroMicroservice.Entities;
using InfraMiggration;
using Repository.Utilities.Framework;


namespace Repository.HeroMicroservice
{
    public class HeroRepository : RepositoryBase<Hero>, IHeroRepository
    {
        public HeroRepository(HeroAngularContext db) : base (db)
        {

        }
    }
}
