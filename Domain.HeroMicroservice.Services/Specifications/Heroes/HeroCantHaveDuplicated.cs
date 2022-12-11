using Domain.Utilities.Framework.Interface;
using Dominio.HeroMicroservice.Entities;
using Repository.HeroMicroservice;


namespace Domain.HeroMicroservice.Services.Specifications.Heroes
{
    public class HeroCantHaveDuplicated : ISpecification<Hero>
    {
        private readonly IHeroRepository _heroRepository;

        public HeroCantHaveDuplicated(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public bool IsSatisfiedBy(Hero entity)
        {
            return _heroRepository.GetAllRecords().Where(x => x.Name.Equals(entity.Name)).Any();            
        }
    }
}
