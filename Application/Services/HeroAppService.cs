using ApiMock.Dominio.Interfaces;
using Application.Interfaces;
using AutoMapper;
using MockApi.Dominio.Entidades;
using MockApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class HeroAppService : AppServiceBase<Hero, HeroDTO>, IHeroAppService
    {
        private readonly IHeroService _service;

        public HeroAppService(IHeroService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
