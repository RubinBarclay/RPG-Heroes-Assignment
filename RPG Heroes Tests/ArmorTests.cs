using RPG_Heroes.Items;

namespace RPGHeroesTests
{
    public class ArmorTests
    {
        [Fact]
        public void Armor_InstantiateArmorClass_ShouldHaveNameMetalPlateArmor()
        {
            // Arrange
            var expected = "Metal plate armor";

            // Act
            var actual = new Armor("Metal plate armor", 5, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0)).Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Armor_InstantiateArmorClass_ShouldHaveRequiredLevel5()
        {
            // Arrange
            var expected = 5;

            // Act
            var actual = new Armor("Metal plate armor", 5, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0)).RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Armor_InstantiateArmorClass_ShouldHaveSlotBody()
        {
            // Arrange
            var expected = Slot.Body;

            // Act
            var actual = new Armor("Metal plate armor", 5, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0)).Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Armor_InstantiateArmorClass_ShouldHaveArmorTypePlate()
        {
            // Arrange
            var expected = ArmorType.Plate;

            // Act
            var actual = new Armor("Metal plate armor", 5, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0)).Type;


            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Armor_InstantiateArmorClass_ShouldHaveArmorCorrectArmorAttributes()
        {
            // Arrange
            var expected = new ArmorAttribute(2, 0, 0);

            // Act
            var actual = new Armor("Metal plate armor", 5, Slot.Body, ArmorType.Plate, new ArmorAttribute(2, 0, 0)).ArmorAttribute;

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}