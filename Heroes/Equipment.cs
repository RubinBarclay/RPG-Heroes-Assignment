using RPG_Heroes.Interfaces;
using RPG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Heroes
{
    internal class Equipment : IEquipment
    {
        private readonly Dictionary<Slot, Item?> _equipment;

        public void AddItem(Slot slot, Item item)
        {
            _equipment.Add(slot, item);
        }

        public void RemoveItem(Slot slot)
        {
            _equipment.Remove(slot);
        }
    }
}
