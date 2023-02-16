using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Items
{
    internal class Weapon : Item
    {
        public WeaponType Type { get; set; }
        public int WeaponDamage { get; set; }

        public Weapon()
        {
            Slot = Slot.Weapon;
        }
    }
}
