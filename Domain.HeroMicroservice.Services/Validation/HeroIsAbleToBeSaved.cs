using Domain.HeroMicroservice.Services.Specifications.Heroes;
using Domain.Utilities.CrossCutting.Specification.Validation;
using Dominio.HeroMicroservice.Entities;
using Repository.HeroMicroservice;

namespace Domain.HeroMicroservice.Services.Validation
{
    public sealed class HeroIsAbleToBeSaved : SpecValidator<Hero>
    {
        public HeroIsAbleToBeSaved(IHeroRepository repository)
        {
            Add("DuplicateName", new Rule<Hero>(new HeroCantHaveDuplicated(repository), "There is a hero with this name at the Base."));
        }
        
    }
}
