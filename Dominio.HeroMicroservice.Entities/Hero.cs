using Dominio.HeroMicroservice.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.HeroMicroservice.Entities
{
    public class Hero
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Power { get; private set; }
        public string Sidekick { get; private set; }
        public int Idade { get; private set; }
        public string TipoSanguineo { get; private set; }
        public HeroStatsVO HeroStats { get; private set; }

        public virtual EquipmentSlots EquipmentSlots { get; set; }
        public virtual ICollection<Backpack> BackpackList { get; set; }

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
