using RPG_Heroes.Exceptions;
using RPG_Heroes.Heroes;
using RPG_Heroes.Items;
using System.Text;

namespace RPGHeroesTests
{
    public class RogueTests
    {
        [Fact]
        public void Rogue_InstantiateRogueClass_ShouldInstantiateRogueWithNameJohn()
        {
            // Arrange
            var expected = "John";

            // Act
            var actual = new Rogue("John").Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_InstantiateRogueClass_ShouldInstantiateRogueWithLevelOf1()
        {
            // Arrange
            var expected = 1;

            // Act
            var actual = new Rogue("John").Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_InstantiateRogueClass_ShouldInstantiateRogueWithCorrectLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(2, 6, 1);

            // Act
            var actual = new Rogue("John").LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_LevelUpRogue_ShouldLevelUpRogueBy1Level()
        {
            // Arrange
            var expected = 2;

            // Act
            var rogue = new Rogue("John");

            rogue.LevelUp();

            var actual = rogue.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_LevelUpRogue_ShouldIncreaseLevelAttributes()
        {
            // Arrange
            var expected = new HeroAttribute(3, 10, 2);

            // Act
            var rogue = new Rogue("John");

            rogue.LevelUp();

            var actual = rogue.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_EquipWeapon_ShouldEquipPoisonDagger()
        {
            // Arrange
            var expected = new Weapon("Poison dagger", 1, WeaponType.Dagger, 2);

            // Act
            var rogue = new Rogue("John");
            var poisonDagger = new Weapon("Poison dagger", 1, WeaponType.Dagger, 2);

            rogue.Equip(poisonDagger);

            var actual = rogue.Equipment.GetWeapon();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_EquipWeapon_ShouldThrowInvalidWeaponTypeException()
        {
            // Arrange
            var rogue = new Rogue("John");
            var battleAxe = new Weapon("Battle Axe", 1, WeaponType.Axe, 2);

            // Act & Assert
            Assert.Throws<InvalidWeaponTypeException>(() => rogue.Equip(battleAxe));
        }

        [Fact]
        public void Rogue_EquipWeapon_ShouldThrowInvalidWeaponLevelException()
        {
            // Arrange
            var rogue = new Rogue("John");
            var swordOfTrickery = new Weapon("Sword of Trickery", 5, WeaponType.Sword, 8);

            // Act & Assert
            Assert.Throws<InvalidWeaponLevelException>(() => rogue.Equip(swordOfTrickery ));
        }

        [Fact]
        public void Rogue_EquipArmor_ShouldEquipBasicClothArmor()
        {
            // Arrange
            var expected = new Armor("Basic Leather armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            // Act
            var rogue = new Rogue("John");
            var basicLeatherArmor = new Armor("Basic Leather armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            rogue.Equip(basicLeatherArmor);

            var actual = rogue.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_EquipArmor_ShouldReplaceArmorWithNewArmor()
        {
            // Arrange
            var expected = new Armor("Basic Mail Armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(0, 0, 3));

            // Act
            var rogue = new Rogue("John");
            var firstArmor = new Armor("Basic Leather armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));
            var secondArmor = new Armor("Basic Mail Armor", 1, Slot.Body, ArmorType.Mail, new ArmorAttribute(0, 0, 3));

            rogue.Equip(firstArmor);
            rogue.Equip(secondArmor);

            var actual = rogue.Equipment.GetItem(Slot.Body);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_EquipArmor_ShouldThrowInvalidArmorTypeException()
        {
            // Arrange
            var rogue = new Rogue("John");
            var basicClothArmor = new Armor("Basic Cloth Armor", 1, Slot.Body, ArmorType.Cloth, new ArmorAttribute(0, 2, 0));

            // Act & Assert
            Assert.Throws<InvalidArmorTypeException>(() => rogue.Equip(basicClothArmor));
        }

        [Fact]
        public void Rogue_EquipArmor_ShouldThrowInvalidArmorLevelException()
        {
            // Arrange
            var rogue = new Rogue("John");
            var premiumMailArmor = new Armor("Premium Mail Armor", 6, Slot.Body, ArmorType.Mail, new ArmorAttribute(0, 0, 7));

            // Act & Assert
            Assert.Throws<InvalidArmorLevelException>(() => rogue.Equip(premiumMailArmor));
        }

        [Fact]
        public void Rogue_LevelAttributes_ShouldIncreaseWithOnePieceOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(2, 8, 1);

            // Act
            var rogue = new Rogue("John");
            var basicLeatherArmor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            rogue.Equip(basicLeatherArmor);

            var actual = rogue.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_LevelAttributes_ShouldIncreaseWithTwoPiecesOfArmorEquiped()
        {
            // Arrange
            var expected = new HeroAttribute(2, 9, 1);

            // Act
            var rogue = new Rogue("John");
            var basicLeatherArmor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));
            var basicLeatherLeggings = new Armor("Basic Leather Leggings", 1, Slot.Legs, ArmorType.Leather, new ArmorAttribute(0, 1, 0));

            rogue.Equip(basicLeatherArmor);
            rogue.Equip(basicLeatherLeggings);

            var actual = rogue.TotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_Damage_ShouldReturnDamageEqualToLevel1RogueWithNoWeapon()
        {
            // Arrange
            double expected = 1.06; //  1 * (1 + (6 / 100))

            // Act
            var rogue = new Rogue("John");

            double actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Damage_ShouldReturnDamageEqualToLevel1RogueWithWeapon()
        {
            // Arrange
            double expected = 2.12; // 2 * (1 + (6 / 100))

            // Act
            var rogue = new Rogue("John");

            var weapon = new Weapon("Poison dagger", 1, WeaponType.Dagger, 2);

            rogue.Equip(weapon);

            double actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Damage_ShouldReturnDamageEqualToLevel1RogueWithReplacedWeapon()
        {
            // Arrange
            var expected = 3.18; // 3 * (1 + (6 / 100))

            // Act
            var rogue = new Rogue("John");

            var firstWeapon = new Weapon("Poison Dagger", 1, WeaponType.Dagger, 2);
            var secondWeapon = new Weapon("Silver Sword", 1, WeaponType.Sword, 3);

            rogue.Equip(firstWeapon);
            rogue.Equip(secondWeapon);

            var actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Damage_ShouldReturnDamageEqualToLevel1RogueWeaponAndArmor()
        {
            // Arrange
            double expected = 2.16; // 2 * (1 + ((6 + 2) / 100))

            // Act
            var rogue = new Rogue("John");

            var weapon = new Weapon("Poison Dagger", 1, WeaponType.Dagger, 2);
            var armor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            rogue.Equip(weapon);
            rogue.Equip(armor);

            double actual = rogue.Damage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Display_ShouldDisplayDefaultRogueState()
        {
            // Arrange

            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: John");
            expectedState.AppendLine($"Class: Rogue");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 2");
            expectedState.AppendLine($"Dexterity: 6");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 1,06");

            var expected = expectedState.ToString();

            // Act
            var rogue = new Rogue("John");

            var actual = rogue.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Display_ShouldDisplayRogueStateWithWeaponEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: John");
            expectedState.AppendLine($"Class: Rogue");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 2");
            expectedState.AppendLine($"Dexterity: 6");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 2,12");

            var expected = expectedState.ToString();

            // Act
            var rogue = new Rogue("John");

            var weapon = new Weapon("Poison Dagger", 1, WeaponType.Dagger, 2);

            rogue.Equip(weapon);

            var actual = rogue.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Display_ShouldDisplayRogueStateWithArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: John");
            expectedState.AppendLine($"Class: Rogue");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 2");
            expectedState.AppendLine($"Dexterity: 8");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 1,08");

            var expected = expectedState.ToString();

            // Act
            var rogue = new Rogue("John");

            var armor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            rogue.Equip(armor);

            var actual = rogue.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_Display_ShouldDisplayRogueStateWithWeaponAndArmorEquiped()
        {
            // Arrange
            var expectedState = new StringBuilder();

            expectedState.AppendLine($"Name: John");
            expectedState.AppendLine($"Class: Rogue");
            expectedState.AppendLine($"Level: 1");
            expectedState.AppendLine($"Strength: 2");
            expectedState.AppendLine($"Dexterity: 8");
            expectedState.AppendLine($"Intelligence: 1");
            expectedState.AppendLine($"Damage: 2,16");

            var expected = expectedState.ToString();

            // Act
            var rogue = new Rogue("John");

            var weapon = new Weapon("Poison Dagger", 1, WeaponType.Dagger, 2);
            var armor = new Armor("Basic Leather Armor", 1, Slot.Body, ArmorType.Leather, new ArmorAttribute(0, 2, 0));

            rogue.Equip(weapon);
            rogue.Equip(armor);

            var actual = rogue.Display();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}