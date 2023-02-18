using RPG_Heroes.Exceptions;
using RPG_Heroes.Heroes;
using RPG_Heroes.Items;
using System.Text;

namespace RPGHeroesTests
{
    public class RangerTests
    {
        [Fact]
        public void Ranger_InstantiateRangerClass_ShouldInstantiateRangerWithNameJane()
        {
            // Arrange
            var expected = "Jane";

            // Act
            var actual = new Ranger("Jane").Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_InstantiateRangerClass_ShouldInstantiateRangerWithLevelOf1()
        {
            // Arrange
            var expected = 1;

            // Act
            var actual = new Ranger("Jane").Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_InstantiateRangerClass_ShouldInstantiateRangerWithCorrectLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(1, 7, 1);

            // Act
            var actual = new Ranger("Jane").LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_LevelUpRanger_ShouldLevelUpRangerBy1Level()
        {
            // Arrange
            var expected = 2;

            // Act
            var ranger = new Ranger("Jane");

            ranger.LevelUp();

            var actual = ranger.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_LevelUpRanger_ShouldIncreaseLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(2, 12, 2);

            // Act
            var ranger = new Ranger("Jane");

            ranger.LevelUp();

            var actual = ranger.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_EquipWeapon_ShouldEquipPoisonDagger()
        {
            // Arrange
            var expected = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);

            // Act
            var ranger = new Ranger("Jane");
            var bowOfPrecision = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);

            ranger.Equip(bowOfPrecision);

            var actual = ranger.Equipment.GetWeapon();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_EquipWeapon_ShouldThrowInvalidWeaponTypeException()
        {
            // Arrange
            var ranger = new Ranger("Jane");
            var battleAxe = new Weapon("Battle Axe", 1, WeaponType.Axe, 2);

            // Act & Assert
            Assert.Throws<InvalidWeaponTypeException>(() => ranger.Equip(battleAxe));
        }

        [Fact]
        public void Ranger_EquipWeapon_ShouldThrowInvalidWeaponLevelException()
        {
            // Arrange
            var ranger = new Ranger("Jane");
            var bowOfFury = new Weapon("Bow of Fury", 5, WeaponType.Bow, 8);

            // Act & Assert
            Assert.Throws<InvalidWeaponLevelException>(() => ranger.Equip(bowOfFury));
        }

        [Fact]
        public void Ranger_EquipArmor_ShouldEquipBasicClothArmor()
        {
            // Arrange
            var expected = new Armor("Basic Leather armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            // Act
            var ranger = new Ranger("Jane");
            var basicLeatherArmor = new Armor("Basic Leather armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            ranger.Equip(basicLeatherArmor);

            var actual = ranger.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_EquipArmor_ShouldReplaceArmorWithNewArmor()
        {
            // Arrange
            var expected = new Armor("Basic Mail Armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 2, 0));

            // Act
            var ranger = new Ranger("Jane");
            var firstArmor = new Armor("Basic Leather armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));
            var secondArmor = new Armor("Basic Mail Armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(1, 2, 0));

            ranger.Equip(firstArmor);
            ranger.Equip(secondArmor);

            var actual = ranger.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_EquipArmor_ShouldThrowInvalidArmorTypeException()
        {
            // Arrange
            var ranger = new Ranger("Jane");
            var basicClothArmor = new Armor("Basic Cloth Armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 2, 0));

            // Act & Assert
            Assert.Throws<InvalidArmorTypeException>(() => ranger.Equip(basicClothArmor));
        }

        [Fact]
        public void Ranger_EquipArmor_ShouldThrowInvalidArmorLevelException()
        {
            // Arrange
            var ranger = new Ranger("Jane");
            var premiumMailArmor = new Armor("Premium Mail Armor", 6, Slot.Body, ArmorType.Mail, new ArmorAttribute(2, 3, 0));

            // Act & Assert
            Assert.Throws<InvalidArmorLevelException>(() => ranger.Equip(premiumMailArmor));
        }

        [Fact]
        public void Ranger_LevelAttributes_ShouldIncreaseWithOnePieceOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(1, 9, 1);

            // Act
            var ranger = new Ranger("Jane");
            var basicLeatherArmor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            ranger.Equip(basicLeatherArmor);

            var actual = ranger.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_LevelAttributes_ShouldIncreaseWithTwoPiecesOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(1, 10, 1);

            // Act
            var ranger = new Ranger("Jane");
            var basicLeatherArmor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));
            var basicLeatherLeggings = new Armor("Basic Leather Leggings", 1, Slot.Legs, ArmorType.Leather, new ArmorAttribute(0, 1, 0));

            ranger.Equip(basicLeatherArmor);
            ranger.Equip(basicLeatherLeggings);

            var actual = ranger.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_Damage_ShouldReturnDamageEqualToLevel1RangerWithNoWeapon()
        {
            // Arrange
            double expected = 1.07; //  1 * (1 + (7 / 100))

            // Act
            var ranger = new Ranger("Jane");

            double actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Damage_ShouldReturnDamageEqualToLevel1RangerWithWeapon()
        {
            // Arrange
            double expected = 2.14; // 2 * (1 + (7 / 100))

            // Act
            var ranger = new Ranger("Jane");

            var weapon = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);

            ranger.Equip(weapon);

            double actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Damage_ShouldReturnDamageEqualToLevel1RangerWithReplacedWeapon()
        {
            // Arrange
            var expected = 3.21; // 3 * (1 + (7 / 100))

            // Act
            var ranger = new Ranger("Jane");

            var firstWeapon = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);
            var secondWeapon = new Weapon("Silver Bow", 1, WeaponType.Bow, 3);

            ranger.Equip(firstWeapon);
            ranger.Equip(secondWeapon);

            var actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Damage_ShouldReturnDamageEqualToLevel1RangerWeaponAndArmor()
        {
            // Arrange
            double expected = 2.18; // 2 * (1 + ((7 + 2) / 100))

            // Act
            var ranger = new Ranger("Jane");

            var weapon = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);
            var armor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            ranger.Equip(weapon);
            ranger.Equip(armor);

            double actual = ranger.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Display_ShouldDisplayDefaultRangerState()
        {
            // Arrange

            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jane");
            expectedState.AppendLine($"Class: Ranger");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 7");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 1,07");

            var expected = expectedState.ToString();

            // Act
            var ranger = new Ranger("Jane");

            var actual = ranger.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Display_ShouldDisplayRangerStateWithWeaponEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jane");
            expectedState.AppendLine($"Class: Ranger");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 7");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 2,14");

            var expected = expectedState.ToString();

            // Act
            var ranger = new Ranger("Jane");

            var weapon = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);

            ranger.Equip(weapon);

            var actual = ranger.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Display_ShouldDisplayRangerStateWithArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jane");
            expectedState.AppendLine($"Class: Ranger");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 9");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 1,09");

            var expected = expectedState.ToString();

            // Act
            var ranger = new Ranger("Jane");

            var armor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            ranger.Equip(armor);

            var actual = ranger.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_Display_ShouldDisplayRangerStateWithWeaponAndArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: Jane");
            expectedState.AppendLine($"Class: Ranger");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 1");
            expectedState.AppendLine($"Dexterity: 9");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 2,18");

            var expected = expectedState.ToString();

            // Act
            var ranger = new Ranger("Jane");

            var weapon = new Weapon("Bow of Precision", 1, WeaponType.Bow, 2);
            var armor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            ranger.Equip(weapon);
            ranger.Equip(armor);

            var actual = ranger.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}