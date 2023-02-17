using RPG_Heroes.Exceptions;
using RPG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Heroes
{
    internal class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            Class = HeroClass.Ranger;
            Equipment = new Equipment();
            LevelAttributes = new HeroAttribute(1, 7, 1);
            ValidWeaponTypes = new List<WeaponType>() { WeaponType.Bow };
            ValidArmorTypes = new List<ArmorType>() { ArmorType.Leather, ArmorType.Mail };
        }

        public override void LevelUp()
        {
            // Increase attributes by specified amount
            LevelAttributes.Increment(1, 5, 1);

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

        public override double Damage()
        {
            double damagingAttribute = Convert.ToDouble(TotalAttributes().Dexterity);

            Weapon? currentWeapon = (Weapon)Equipment.GetWeapon();
            double weaponDamage = currentWeapon?.WeaponDamage ?? 1; // If no weapon is equiped aka is null, set damage to 1

            double damage = Convert.ToDouble(weaponDamage) * (1.0 + damagingAttribute / 100.0);

            return Math.Round(damage, 2);
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
