using AutoMapper;
using Domain.HeroMicroservice.Services.Interfaces;
using Domain.Utilities.CrossCutting;
using Dominio.HeroMicroservice.Entities;
using MockApi.DTO;
using Repository.HeroMicroservice;

namespace Domain.HeroMicroservice.Services
{
    public class HeroService : ServiceBase<Hero, HeroDTO>, IHeroService
    {
        private readonly IHeroRepository _repository;

        public HeroService(IHeroRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }


    }
}
