using AutoMapper;
using Domain.HeroMicroservice.Services.Interfaces;
using Domain.HeroMicroservice.Services.Validation;
using Domain.Utilities.Framework;
using Dominio.HeroMicroservice.Entities;
using HeroMicroservice.DTO;
using Repository.HeroMicroservice;

namespace Domain.HeroMicroservice.Services
{
    public class HeroService : ServiceBase<Hero, HeroDTO>, IHeroService
    {
        private readonly IHeroRepository _repository;

        public HeroService(IHeroRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            RegisterIsValidToBeChanged += register => new HeroIsAbleToBeSaved(repository).Validate(register);
        }

    }
}
