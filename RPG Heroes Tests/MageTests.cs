using RPG_Heroes.Exceptions;
using RPG_Heroes.Heroes;
using RPG_Heroes.Items;
using System.Text;

namespace RPGHeroesTests
{
    public class MageTests
    {
        [Fact]
        public void Mage_InstantiateMageClass_ShouldInstantiateMageWithNameJill()
        {
            // Arrange
            var expected = "Jill";

            // Act
            var actual = new Mage("Jill").Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_InstantiateMageClass_ShouldInstantiateMageWithLevelOf1()
        {
            // Arrange
            var expected = 1;

            // Act
            var actual = new Mage("Jill").Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_InstantiateMageClass_ShouldInstantiateMageWithCorrectLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(1, 1, 8);

            // Act
            var actual = new Mage("Jill").LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_LevelUpMage_ShouldLevelUpMageBy1Level()
        {
            // Arrange
            var expected = 2;

            // Act
            var mage = new Mage("Jill");

            mage.LevelUp();

            var actual = mage.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_LevelUpMage_ShouldIncreaseLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(2, 2, 13);

            // Act
            var mage = new Mage("Jill");

            mage.LevelUp();

            var actual = mage.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_EquipWeapon_ShouldEquipIceWand()
        {
            // Arrange
            var expected = new Weapon("Ice wand", 1, WeaponType.Wand, 2);

            // Act
            var mage = new Mage("Jill");
            var iceWand = new Weapon("Ice wand", 1, WeaponType.Wand, 2);

            mage.Equip(iceWand);

            var actual = mage.Equipment.GetWeapon();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_EquipWeapon_ShouldThrowInvalidWeaponTypeException()
        {
            // Arrange
            var mage = new Mage("Jill");
            var battleAxe = new Weapon("Battle Axe", 1, WeaponType.Axe, 2);

            // Act & Assert
            Assert.Throws<InvalidWeaponTypeException>(() => mage.Equip(battleAxe));
        }

        [Fact]
        public void Mage_EquipWeapon_ShouldThrowInvalidWeaponLevelException()
        {
            // Arrange
            var mage = new Mage("Jill");
            var staffOfSorcery = new Weapon("Staff of Sorcery", 5, WeaponType.Staff, 8);

            // Act & Assert
            Assert.Throws<InvalidWeaponLevelException>(() => mage.Equip(staffOfSorcery));
        }

        [Fact]
        public void Mage_EquipArmor_ShouldEquipBasicClothArmor()
        {
            // Arrange
            var expected = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            // Act
            var mage = new Mage("Jill");
            var basicClothArmor = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            mage.Equip(basicClothArmor);

            var actual = mage.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_EquipArmor_ShouldReplaceArmorWithNewArmor()
        {
            // Arrange
            var expected = new Armor("Simple Wizard Robe", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 3));

            // Act
            var mage = new Mage("Jill");
            var firstArmor = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));
            var secondArmor = new Armor("Simple Wizard Robe", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 3));

            mage.Equip(firstArmor);
            mage.Equip(secondArmor);

            var actual = mage.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_EquipArmor_ShouldThrowInvalidArmorTypeException()
        {
            // Arrange
            var mage = new Mage("Jill");
            var basicMailArmor = new Armor("Basic mail armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 0, 0));

            // Act & Assert
            Assert.Throws<InvalidArmorTypeException>(() => mage.Equip(basicMailArmor));
        }

        [Fact]
        public void Mage_EquipArmor_ShouldThrowInvalidArmorLevelException()
        {
            // Arrange
            var mage = new Mage("Jill");
            var robeOfSupremecy = new Armor("Robe of Supremecy ", 10, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 10));

            // Act & Assert
            Assert.Throws<InvalidArmorLevelException>(() => mage.Equip(robeOfSupremecy));
        }

        [Fact]
        public void Mage_LevelAttributes_ShouldIncreaseWithOnePieceOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(1, 1, 10);

            // Act
            var mage = new Mage("Jill");
            var basicClothArmor = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            mage.Equip(basicClothArmor);

            var actual = mage.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_LevelAttributes_ShouldIncreaseWithTwoPiecesOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(1, 1, 11);

            // Act
            var mage = new Mage("Jill");
            var mysteriousHood = new Armor("Mysterious hood", 1, Slot.Head, ArmorType.Cloth, new ArmorAttribute(0, 0, 1));
            var basicClothArmor = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            mage.Equip(mysteriousHood);
            mage.Equip(basicClothArmor);

            var actual = mage.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Mage_Damage_ShouldReturnDamageEqualToLevel1MageWithNoWeapon()
        {
            // Arrange
            double expected = 1.08; //  1 * (1 + (8 / 100))

            // Act
            var mage = new Mage("Jill");

            double actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Damage_ShouldReturnDamageEqualToLevel1MageWithWeapon()
        {
            // Arrange
            double expected = 2.16; // 2 * (1 + (8 / 100))

            // Act
            var mage = new Mage("Jill");

            var weapon = new Weapon("Ice wand", 1, WeaponType.Wand, 2);

            mage.Equip(weapon);

            double actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Damage_ShouldReturnDamageEqualToLevel1MageWithReplacedWeapon()
        {
            // Arrange
            var expected = 3.24; // 3 * (1 + (8 / 100))

            // Act
            var mage = new Mage("Jill");

            var firstWeapon  = new Weapon("Ice wand", 1, WeaponType.Wand, 2);
            var secondWeapon = new Weapon("Staff of Souls", 1, WeaponType.Staff, 3);

            mage.Equip(firstWeapon);
            mage.Equip(secondWeapon);

            var actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Damage_ShouldReturnDamageEqualToLevel1MageWeaponAndArmor()
        {
            // Arrange
            double expected = 2.2; // 2 * (1 + ((8 + 2) / 100))

            // Act
            var mage = new Mage("Jill");

            var weapon  = new Weapon("Ice wand", 1, WeaponType.Wand, 2);
            var armor = new Armor("Basic Cloth Armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            mage.Equip(weapon);
            mage.Equip(armor);

            double actual = mage.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Display_ShouldDisplayDefaultMageState()
        {
            // Arrange

            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jill");
            expectedState.AppendLine($"Class: Mage");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 1");
            expectedState.AppendLine($"Intelligence: 8");
            expectedState.AppendLine($"Damage: 1,08");

            var expected = expectedState.ToString();

            // Act
            var mage = new Mage("Jill");

            var actual = mage.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Display_ShouldDisplayMageStateWithWeaponEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jill");
            expectedState.AppendLine($"Class: Mage");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 1");
            expectedState.AppendLine($"Intelligence: 8");
            expectedState.AppendLine($"Damage: 2,16");

            var expected = expectedState.ToString();

            // Act
            var mage = new Mage("Jill");

            var weapon = new Weapon("Ice wand", 1, WeaponType.Wand, 2);

            mage.Equip(weapon);

            var actual = mage.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Display_ShouldDisplayMageStateWithArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jill");
            expectedState.AppendLine($"Class: Mage");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 1");
            expectedState.AppendLine($"Intelligence: 10");
            expectedState.AppendLine($"Damage: 1,1");

            var expected = expectedState.ToString();

            // Act
            var mage = new Mage("Jill");

            var armor = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            mage.Equip(armor);

            var actual = mage.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Mage_Display_ShouldDisplayMageStateWithWeaponAndArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jill");
            expectedState.AppendLine($"Class: Mage");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 1");
            expectedState.AppendLine($"Intelligence: 10");
            expectedState.AppendLine($"Damage: 2,2");

            var expected = expectedState.ToString();

            // Act
            var mage = new Mage("Jill");

            var weapon = new Weapon("Ice wand", 1, WeaponType.Wand, 2);
            var armor = new Armor("Basic Cloth armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 0, 2));

            mage.Equip(weapon);
            mage.Equip(armor);

            var actual = mage.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}