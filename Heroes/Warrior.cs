using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Heroes
{
    internal class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(5, 2, 1); // Use dependency inversion instead, not SOLID!!!
        }

        public override void LevelUp()
        {
            // Increase attributes by specified amount
            LevelAttributes.Strength += 5;
            LevelAttributes.Dexterity += 2;
            LevelAttributes.Intelligence += 1;

            // Increase level by 1
            Level++;
        }
    }
}
