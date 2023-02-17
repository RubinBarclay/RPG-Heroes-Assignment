using RPG_Heroes.Interfaces;
using RPG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Heroes
{
    abstract class Hero
    {
        public string Name { get; set; }
        public HeroClass Class { get; set; }
        public int Level { get; set; }
        public HeroAttribute? LevelAttributes { get; set; }
        public Equipment Equipment { get; set; }
        public List<WeaponType>? ValidWeaponTypes { get; set; }
        public List<ArmorType>? ValidArmorTypes { get; set; }

        public Hero(string name)
        {
            Name = name;
            Level = 1;
        }

        public abstract void LevelUp();
        public abstract void Equip(Weapon weapon);
        public abstract void Equip(Armor armor);
        public abstract double Damage();
        public abstract string Display();

        public HeroAttribute TotalAttributes()
        {
            var totalAttributes = new HeroAttribute(LevelAttributes.Strength, LevelAttributes.Dexterity, LevelAttributes.Intelligence);

            foreach (Item armor in Equipment.GetArmor())
            {
                Armor armorItem = (Armor)armor;

                totalAttributes.Strength += armorItem.ArmorAttribute.Strength;
                totalAttributes.Dexterity += armorItem.ArmorAttribute.Dexterity;
                totalAttributes.Intelligence += armorItem.ArmorAttribute.Intelligence;
            }

            return totalAttributes;
        }
    }
}
