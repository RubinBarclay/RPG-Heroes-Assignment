using RPG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Interfaces
{
    internal interface IEquipment
    {
        void AddItem(Slot slot, Item item);
        void RemoveItem(Slot slot);
    }
}
