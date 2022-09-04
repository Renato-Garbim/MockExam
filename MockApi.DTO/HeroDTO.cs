using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMicroservice.DTO
{
    public class HeroDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Sidekick { get; set; }
        public int Idade { get; set; }
        public string TipoSanguineo { get; set; }

    }
}
