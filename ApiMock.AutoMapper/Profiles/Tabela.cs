﻿using Dominio.HeroMicroservice.Entities;
using HeroMicroservice.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMicroservice.AutoMapper.Profiles
{
    public class Tabela : global::AutoMapper.Profile
    {
        public Tabela()
        {

            CreateMap<Hero, HeroDTO>();

            CreateMap<HeroDTO, Hero>()
                .ConstructUsing(x => new Hero(x.Id, x.Name, x.Power, x.Sidekick, x.Idade, x.TipoSanguineo));

        }
    }
}
