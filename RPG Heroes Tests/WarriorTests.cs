using RPG_Heroes.Exceptions;
using RPG_Heroes.Heroes;
using RPG_Heroes.Items;
using System.Text;

namespace RPGHeroesTests
{
    public class WarriorTests
    {
        [Fact]
        public void Warrior_InstantiateWarriorClass_ShouldInstantiateWarriorWithNameJeff()
        {
            // Arrange
            var expected = "Jeff";

            // Act
            var actual = new Warrior("Jeff").Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_InstantiateWarriorClass_ShouldInstantiateWarriorWithLevelOf1()
        {
            // Arrange
            var expected = 1;

            // Act
            var actual = new Warrior("Jeff").Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_InstantiateWarriorClass_ShouldInstantiateWarriorWithCorrectLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(5, 2, 1);

            // Act
            var actual = new Warrior("Jeff").LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_LevelUpWarrior_ShouldLevelUpWarriorBy1Level()
        {
            // Arrange
            var expected = 2;

            // Act
            var warrior = new Warrior("Jeff");

            warrior.LevelUp();

            var actual = warrior.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_LevelUpWarrior_ShouldIncreaseLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(8, 4, 2);

            // Act
            var warrior = new Warrior("Jeff");

            warrior.LevelUp();

            var actual = warrior.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_EquipWeapon_ShouldEquipBattleAxe()
        {
            // Arrange
            var expected = new Weapon("Battle Axe", 1, WeaponType.Axe, 2);

            // Act
            var warrior = new Warrior("Jeff");
            var battleAxe = new Weapon("Battle Axe", 1, WeaponType.Axe, 2);

            warrior.Equip(battleAxe);

            var actual = warrior.Equipment.GetWeapon();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_EquipWeapon_ShouldThrowInvalidWeaponTypeException()
        {
            // Arrange
            var warrior = new Warrior("Jeff");
            var iceWand = new Weapon("Ice wand", 1, WeaponType.Wand, 1);

            // Act & Assert
            Assert.Throws<InvalidWeaponTypeException>(() => warrior.Equip(iceWand));
        }

        [Fact]
        public void Warrior_EquipWeapon_ShouldThrowInvalidWeaponLevelException()
        {
            // Arrange
            var warrior = new Warrior("Jeff");
            var hammerOfDoom = new Weapon("Hammer of Doom", 5, WeaponType.Hammer, 8);

            // Act & Assert
            Assert.Throws<InvalidWeaponLevelException>(() => warrior.Equip(hammerOfDoom));
        }

        [Fact]
        public void Warrior_EquipArmor_ShouldEquipBasicMailArmor()
        {
            // Arrange
            var expected = new Armor("Basic Mail armor", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0));

            // Act
            var warrior = new Warrior("Jeff");
            var firstArmor = new Armor("Standard Plate armor", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(3, 0, 0));
            var secondArmor = new Armor("Basic Mail armor", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0));

            warrior.Equip(firstArmor);
            warrior.Equip(secondArmor);

            var actual = warrior.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_EquipArmor_ShouldReplaceArmorWithNewArmor()
        {
            // Arrange
            var expected = new Armor("Basic Mail armor", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0));

            // Act
            var warrior = new Warrior("Jeff");
            var basicMailArmor = new Armor("Basic Mail armor", 1, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0));

            warrior.Equip(basicMailArmor);

            var actual = warrior.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_EquipArmor_ShouldThrowInvalidArmorTypeException()
        {
            // Arrange
            var warrior = new Warrior("Jeff");
            var sneakyClothArmor = new Armor("Sneaky cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 2, 1));

            // Act & Assert
            Assert.Throws<InvalidArmorTypeException>(() => warrior.Equip(sneakyClothArmor));
        }

        [Fact]
        public void Warrior_EquipArmor_ShouldThrowInvalidArmorLevelException()
        {
            // Arrange
            var warrior = new Warrior("Jeff");
            var premiumPlateArmor = new Armor("Premium Plate armor", 6, Slot.Body, ArmorType.Plate, new ArmorAttribute(5, 0, 0));

            // Act & Assert
            Assert.Throws<InvalidArmorLevelException>(() => warrior.Equip(premiumPlateArmor));
        }

        [Fact]
        public void Warrior_LevelAttributes_ShouldIncreaseWithOnePieceOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(6, 2, 1);

            // Act
            var warrior = new Warrior("Jeff");
            var basicMailArmor = new Armor("Basic mail armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 0, 0));

            warrior.Equip(basicMailArmor);

            var actual = warrior.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_LevelAttributes_ShouldIncreaseWithTwoPiecesOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(7, 2, 1);

            // Act
            var warrior = new Warrior("Jeff");
            var basicMailArmor = new Armor("Basic mail armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 0, 0));
            var basicMailLeggings = new Armor("Basic mail leggings", 1, Slot.Legs, ArmorType.Mail, new ArmorAttribute(1, 0, 0));

            warrior.Equip(basicMailArmor);
            warrior.Equip(basicMailLeggings);

            var actual = warrior.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_Damage_ShouldReturnDamageEqualToLevel1WarriorWithNoWeapon()
        {
            // Arrange
            double expected = 1.05; //  1 * (1 + (5 / 100))

            // Act
            var warrior = new Warrior("Jeff");

            double actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Damage_ShouldReturnDamageEqualToLevel1WarriorWithWeapon()
        {
            // Arrange
            double expected = 2.1; // 2 * (1 + (5 / 100))

            // Act
            var warrior = new Warrior("Jeff");

            var weapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);

            warrior.Equip(weapon);

            double actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Damage_ShouldReturnDamageEqualToLevel1WarriorWithReplacedWeapon()
        {
            // Arrange
            var expected = 3.15; // 3 * (1 + (5 / 100))

            // Act
            var warrior = new Warrior("Jeff");

            var firstWeapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);
            var secondWeapon = new Weapon("Massive Mallet", 1, WeaponType.Hammer, 3);

            warrior.Equip(firstWeapon);
            warrior.Equip(secondWeapon);

            var actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Damage_ShouldReturnDamageEqualToLevel1WarriorWeaponAndArmor()
        {
            // Arrange
            double expected = 2.12; // 2 * (1 + ((5 + 1) / 100))

            // Act
            var warrior = new Warrior("Jeff");

            var weapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);
            var armor = new Armor("Basic mail armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 0, 0));

            warrior.Equip(weapon);
            warrior.Equip(armor);

            double actual = warrior.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Display_ShouldDisplayDefaultWarriorState()
        {
            // Arrange

            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jeff");
            expectedState.AppendLine($"Class: Warrior");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 5");
            expectedState.AppendLine($"Dexterity: 2");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 1,05");

            var expected = expectedState.ToString();

            // Act
            var warrior = new Warrior("Jeff");

            var actual = warrior.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Display_ShouldDisplayWarriorStateWithWeaponEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jeff");
            expectedState.AppendLine($"Class: Warrior");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 5");
            expectedState.AppendLine($"Dexterity: 2");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 2,1");

            var expected = expectedState.ToString();

            // Act
            var warrior = new Warrior("Jeff");

            var weapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);

            warrior.Equip(weapon);

            var actual = warrior.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Display_ShouldDisplayWarriorStateWithArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jeff");
            expectedState.AppendLine($"Class: Warrior");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 6");
            expectedState.AppendLine($"Dexterity: 2");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 1,06");

            var expected = expectedState.ToString();

            // Act
            var warrior = new Warrior("Jeff");

            var armor = new Armor("Basic mail armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 0, 0));

            warrior.Equip(armor);

            var actual = warrior.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_Display_ShouldDisplayWarriorStateWithWeaponAndArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jeff");
            expectedState.AppendLine($"Class: Warrior");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 6");
            expectedState.AppendLine($"Dexterity: 2");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 2,12");

            var expected = expectedState.ToString();

            // Act
            var warrior = new Warrior("Jeff");

            var weapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);
            var armor = new Armor("Basic mail armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 0, 0));

            warrior.Equip(weapon);
            warrior.Equip(armor);

            var actual = warrior.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}