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
            Class = HeroClass.Warrior;
            Equipment = new Equipment();
            LevelAttributes = new HeroAttribute(5, 2, 1);
            ValidWeaponTypes = new List<WeaponType>() { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword };
            ValidArmorTypes = new List<ArmorType>() { ArmorType.Mail, ArmorType.Plate };
        }

        public override void LevelUp()
        {
            // Increase attributes by specified amount
            LevelAttributes.Increment(3, 2, 1);

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
                throw new InvalidWeaponTypeException(Class, weapon.Type);
            }

            Equipment.AddItem(weapon.Slot, weapon);
        }

        public override void Equip(Armor armor)
        {
            if (armor.RequiredLevel > Level)
            {
                throw new InvalidArmorLevelException();
            }

            if (!ValidArmorTypes.Contains(armor.Type))
            {
                throw new InvalidArmorTypeException(Class, armor.Type);
            }

            Equipment.AddItem(armor.Slot, armor);
        }

        public override int Damage()
        {
            int damagingAttribute = TotalAttributes().Strength;

            Weapon? currentWeapon = (Weapon)Equipment.GetWeapon();
            int weaponDamage = currentWeapon?.WeaponDamage ?? 1; // If no weapon is equiped aka is null, set damage to 1

            return weaponDamage * (1 + damagingAttribute / 100);
        }

        public override string Display()
        {
            var info = new StringBuilder();

            info.AppendLine($"Name: {Name}");
            info.AppendLine($"Class: {Class}");
            info.AppendLine($"Level: {Level}");
            info.AppendLine($"Strength: {TotalAttributes().Strength}");
            info.AppendLine($"Dexterity: {TotalAttributes().Dexterity}");
            info.AppendLine($"Intelligence: {TotalAttributes().Intelligence}");
            info.AppendLine($"Damage: {Damage()}");

            return info.ToString();
        }
    }
}
