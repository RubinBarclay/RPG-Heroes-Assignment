using RPG_Heroes.Heroes;
using RPG_Heroes.Items;

namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            var jeff = new Warrior("Jeff");

            //Console.WriteLine($"{jeff.Name} lvl: {jeff.Level} ");
            //Console.WriteLine($"{jeff.LevelAttributes.Strength.ToString()} {jeff.LevelAttributes.Dexterity.ToString()}, {jeff.LevelAttributes.Intelligence.ToString()}");

            //jeff.LevelUp();

            //Console.WriteLine($"{jeff.Name} lvl: {jeff.Level} ");
            //Console.WriteLine($"8 = {jeff.LevelAttributes.Strength.ToString()} 4 = {jeff.LevelAttributes.Dexterity.ToString()}, 2 = {jeff.LevelAttributes.Intelligence.ToString()}");

            var validWeapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);
            Console.WriteLine($"Name: {validWeapon.Name} \nRequired Level: {validWeapon.RequiredLevel} \nType: {validWeapon.Type} \nDamage: {validWeapon.WeaponDamage} \n");

            var validArmor = new Armor("Common Plate Chest", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(1, 0, 0));
            Console.WriteLine($"Name: {validArmor.Name} \nRequired Level: {validArmor.RequiredLevel} \nType: {validArmor.Type} \nSlot: {validArmor.Slot} \nAttributes: Str {validArmor.ArmorAttribute.Strength}, Dex {validArmor.ArmorAttribute.Dexterity}, Int {validArmor.ArmorAttribute.Intelligence} \n");

            jeff.Equip(validWeapon);

            Console.WriteLine($"Weapon: {jeff.Equipment.GetWeapon().Name}");

            //var invalidWeapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);
            //Console.WriteLine($"Name: {validWeapon.Name} \nRequired Level: {validWeapon.RequiredLevel} \nType: {validWeapon.Type} \nDamage: {validWeapon.WeaponDamage} \n");

            //var invalidArmor = new Armor("Common Plate Chest", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(1, 0, 0));
            //Console.WriteLine($"Name: {validArmor.Name} \nRequired Level: {validArmor.RequiredLevel} \nType: {validArmor.Type} \nSlot: {validArmor.Slot} \nAttributes: Str {validArmor.ArmorAttribute.Strength}, Dex {validArmor.ArmorAttribute.Dexterity}, Int {validArmor.ArmorAttribute.Intelligence} \n");
        }
    }
}