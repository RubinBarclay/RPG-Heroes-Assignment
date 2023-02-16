using RPG_Heroes.Exceptions;
using RPG_Heroes.Items;
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
            ValidWeaponTypes = new List<WeaponType>() { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword };
            ValidArmorTypes = new List<ArmorType>() { ArmorType.Mail, ArmorType.Plate };
        }

        public override void LevelUp()
        {
            // Increase attributes by specified amount
            LevelAttributes.Increment(5, 2, 1);

            // Increase level by 1
            Level++;
        }

        public override void Equip(Weapon weapon)
        {
            if (weapon.RequiredLevel > Level)
            {
                throw new InvalidWeaponLevelException();
            }

            if (!ValidWeaponTypes.Contains(weapon.Type))
            {
                throw new InvalidWeaponTypeException(HeroType.Warrior, weapon.Type);
            }

            Equipment.AddItem(weapon.Slot, weapon);
        }

        public override void Equip(Armor armor)
        {
            if (armor.RequiredLevel > Level)
            {
                throw new InvalidArmorLevelException();
            }

            if (ValidArmorTypes.Contains(armor.Type))
            {
                throw new InvalidArmorTypeException(HeroType.Warrior, armor.Type);
            }

            Equipment.AddItem(armor.Slot, armor);
        }
    }
}
