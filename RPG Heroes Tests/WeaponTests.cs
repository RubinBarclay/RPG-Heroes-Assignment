using RPG_Heroes.Items;

namespace RPGHeroesTests
{
    public class WeaponTests
    {
        [Fact]
        public void Weapon_InstantiateWeaponClass_ShouldHaveNameExcalibur()
        {
            // Arrange
            var expected = "Excalibur";

            // Act
            var actual = new Weapon("Excalibur", 10, WeaponType.Sword, 100).Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Weapon_InstantiateWeaponClass_ShouldHaveRequiredLevel10()
        {
            // Arrange
            var expected = 10;

            // Act
            var actual = new Weapon("Excalibur", 10, WeaponType.Sword, 100).RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Weapon_InstantiateWeaponClass_ShouldHaveSlotWeapon()
        {
            // Arrange
            var expected = Slot.Weapon;

            // Act
            var actual = new Weapon("Excalibur", 1, WeaponType.Sword, 100).Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Weapon_InstantiateWeaponClass_ShouldHaveWeaponTypeSword()
        {
            // Arrange
            var expected = WeaponType.Sword;

            // Act
            var actual = new Weapon("Excalibur", 1, WeaponType.Sword, 100).Type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Weapon_InstantiateWeaponClass_ShouldHaveDamageOf100()
        {
            // Arrange
            var expected = 100;

            // Act
            var actual = new Weapon("Excalibur", 1, WeaponType.Sword, 100).WeaponDamage;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}