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
        public abstract int Damage();
        public abstract string Display();

        public HeroAttribute TotalAttributes()
        {
            var armorStrengthBonus = Equipment.GetArmor().Sum((Armor armor) => armor.ArmorAttribute.Strength); 
            var armorDexterityBonus  = Equipment.GetArmor().Sum((Armor armor) => armor.ArmorAttribute.Dexterity); 
            var armorIntelligenceBonus = Equipment.GetArmor().Sum((Armor armor) => armor.ArmorAttribute.Intelligence);

            var totalStrength = LevelAttributes.Strength + armorStrengthBonus;
            var totalDexterity = LevelAttributes.Dexterity + armorDexterityBonus;
            var totalIntelligence = LevelAttributes.Intelligence + armorIntelligenceBonus;

            var totalAttributes = new HeroAttribute(totalStrength, totalDexterity, totalIntelligence);

            return totalAttributes;
        }
    }
}
