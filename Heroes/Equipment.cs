using RPG_Heroes.Interfaces;
using RPG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public Item GetItem(Slot slot)
        {
            return _equipment[slot];
        }

        public Item GetWeapon()
        {
            return _equipment[Slot.Weapon];
        }

        public List<Item> GetArmor()
        {
            var armorList = new List<Item>();

            foreach (KeyValuePair<Slot, Item?> armor in _equipment)
            {
                if (armor.Value is Armor)
                {
                    armorList.Add(armor.Value);
                }
            }

            return armorList;
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
