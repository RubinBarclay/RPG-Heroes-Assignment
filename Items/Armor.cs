﻿using RPG_Heroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Items
{
    internal class Armor
    {
        ArmorType Type { get; set; }
        HeroAttribute ArmorAttribute { get; set; }
    }
}