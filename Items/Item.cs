using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Items
{
    abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }

        public Item(string name, int requiredLevel) 
        {
            Name = name;
            RequiredLevel = requiredLevel;
        }
    }
}
