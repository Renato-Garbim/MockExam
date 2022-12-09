using Domain.Utilities.CrossCutting.Interface;
using Domain.Utilities.CrossCutting.Specification;
using Dominio.HeroMicroservice.Entities;
using Repository.HeroMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
