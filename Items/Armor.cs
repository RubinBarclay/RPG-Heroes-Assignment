using RPG_Heroes.Heroes;
using RPG_Heroes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Items
{
    internal class Armor : Item
    {
        public ArmorType Type { get; set; }
        public IAttribute ArmorAttribute { get; set; }

        public Armor(string name, int requiredLevel, Slot slot, ArmorType type, IAttribute attributes) : base(name, requiredLevel)
        {
            Slot = slot;
            Type = type;
            ArmorAttribute = attributes;
        }
    }
}
