using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.HeroMicroservice.Entities
{
    public class Backpack
    {
        public int BackpackId { get; private set; }
        public int HeroId { get; private set; }
        public int Slots { get; private set; }

        public virtual Hero Hero { get; set; }

        public Backpack(int backpackId, int heroId, int slots)
        {
            BackpackId = backpackId;
            HeroId = heroId;
            Slots = slots;
        }

    }
}
