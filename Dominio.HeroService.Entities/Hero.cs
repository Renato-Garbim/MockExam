using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.HeroService.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Sidekick { get; set; }
        public int Idade { get; set; }
        public string TipoSanguineo { get; set; }

        public Hero()
        {

        }

        public Hero(int id, string name, string power, string sidekick, int idade, string tipoSanguineo)
        {
            Id = id;
            Name = name;
            Power = power;
            Sidekick = sidekick;
            Idade = idade;
            TipoSanguineo = tipoSanguineo;
        }

    }
}
