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
        private readonly Dictionary<Slot, Item?> _equipment = new();

        public Equipment()
        {
            _equipment.Add(Slot.Weapon, null);
            _equipment.Add(Slot.Head, null);
            _equipment.Add(Slot.Body, null);
            _equipment.Add(Slot.Legs, null);
        }

        public Weapon GetWeapon()
        {
            return (Weapon)_equipment[Slot.Weapon];
        }

        public List<Armor> GetArmor()
        {
            return (List<Armor>)_equipment.Values.Where((Item item) => item is Armor);
        }

        public void AddItem(Slot slot, Item item)
        {
            _equipment[slot] = item;
        }

        public void RemoveItem(Slot slot)
        {
            _equipment.Remove(slot);
        }
    }
}
