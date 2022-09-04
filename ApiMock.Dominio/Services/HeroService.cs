using ApiMock.Dominio.Interfaces;
using MockApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMock.Dominio.Services
{
    public class HeroService : ServiceBase<Hero>, IHeroService
    {
        private readonly IHeroRepository _repository;

        public HeroService(IHeroRepository repository) : base(repository)
        {
            _repository = repository;
        }


    }
}
