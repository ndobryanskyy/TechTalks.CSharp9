using FluentAssertions;
using Xunit;

namespace LanguageFeatures.LearningTests
{
    public class Robot
    {
        public string Name { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

        public int? GunPower { get; set; }

        public string? ManufacturerName { get; set; }
    }

    public class InitPropertiesLearningTests
    {
        [Fact]
        public void Cannot_Be_Created_Uninitialized()
        {
            var robot = new Robot();

            robot.Name.Should().NotBeEmpty();
            robot.SerialNumber.Should().NotBeEmpty();
        }
        
        /* ManufacturerName
        [Fact]
        public void HomeTown_Can_Not_Be_Changed()
        {
            var droid = new Robot("A 01", "D-A-1")
            {
                ManufacturerName = "Nikita"
            };
        
            droid.ManufacturerName = "Impostor";
        
            droid.ManufacturerName.Should().Be("Nikita");
        }
        */

        /* Gun Power
        [Theory]
        [InlineData(-10)]
        [InlineData(1001)]
        public void GunPower_Should_Only_Be_Between_0_And_1000(int gunPower)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = new Robot("B 01", "D-B-1")
                {
                    GunPower = gunPower
                };
            });
        }
        */

        /* Name Composition
        [Fact]
        public void ManufacturerName_Should_Be_In_Robot_Name_IfPresent()
        {
            var robotWithManufacturer = new Robot("C 01", "D-C-1")
            {
                ManufacturerName = "Nikita"
            };

            var robotWithoutManufacturer = new Robot("C 02", "D-C-2");

            robotWithManufacturer.Name.Should().Be("C 01 (by Nikita)");
            robotWithoutManufacturer.Name.Should().Be("C O2");
        }
        */

        /* Juggernaut 250
        [Fact]
        public void Can_Change_GunPower_Of_Juggernaut()
        {
            var defaultJuggernaut = new Juggernaut("J 01", "J-1");
            var juggernautWithIncreasedGunPower = new Juggernaut("J 02", "J-2")
            {
                GunPower = Juggernaut.DefaultGunPower * 2
            };

            defaultJuggernaut.GunPower.Should().Be(250);
            juggernautWithIncreasedGunPower.GunPower.Should().Be(500);
        }
        */
    }
}