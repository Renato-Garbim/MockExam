using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.HeroMicroservice.Entities.ValueObject
{
    public class HeroStatsVO
    {
        public int Strenght { get; private set; }
        public int Dexterity { get; private set; }
        public int Inteligence { get; private set; }
        public int Wisdow { get; private set; }
        public int Faith { get; private set; }

        public HeroStatsVO(int strenght, int dexterity, int inteligence, int wisdow, int faith)
        {
            Strenght = strenght;
            Dexterity = dexterity;
            Inteligence = inteligence;
            Wisdow = wisdow;
            Faith = faith;
        }


    }
}
