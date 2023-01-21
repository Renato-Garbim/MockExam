using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.HeroMicroservice.Entities
{
    public class EquipmentSlots
    {
        public int EquipmentSlotsId { get; private set; }
        public int HeroId { get; private set; }

        public virtual Hero Hero { get; set; }

        public EquipmentSlots(int equipmentSlotsId, int heroId)
        {
            EquipmentSlotsId = equipmentSlotsId;
            HeroId = heroId;
        }





    }
}
