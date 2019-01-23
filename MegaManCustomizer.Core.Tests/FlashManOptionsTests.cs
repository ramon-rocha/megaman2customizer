using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class FlashManOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void PrimaryColor_IsBrightWhite()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Bright White", rom.RobotMasterOptions.FlashMan.PrimaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_IsIndigo()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Indigo", rom.RobotMasterOptions.FlashMan.SecondaryColor.Name);
        }

        [Fact]
        public void RunSpeed_Is1()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(1.0234375m, rom.RobotMasterOptions.FlashMan.RunSpeed);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("0.5")]
        [InlineData("1.0")]
        [InlineData("1.5")]
        [InlineData("2.0")]
        public void RunSpeed_CanBeChanged(string valueText)
        {
            var value = decimal.Parse(valueText);
            var rom = new MegaManRom(_romBytes);
            rom.RobotMasterOptions.FlashMan.RunSpeed = value;
            Assert.Equal(value, rom.RobotMasterOptions.FlashMan.RunSpeed);
        }

        [Fact]
        public void JumpDistance_Is0() // TODO: include fraction
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(0, rom.RobotMasterOptions.FlashMan.JumpDistance);
        }

        [Fact]
        public void JumpHeight_Is4()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(4, rom.RobotMasterOptions.FlashMan.JumpHeight);
        }

        [Fact]
        public void ProjectileCount_Is6()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(6, rom.RobotMasterOptions.FlashMan.ProjectileCount);
        }


        [Fact]
        public void ProjectileSpeed_Is8()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(8, rom.RobotMasterOptions.FlashMan.ProjectileSpeed);
        }

        [Fact]
        public void TimeStopperDelay_Is187()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(0xBB, rom.RobotMasterOptions.FlashMan.TimeStopperDelay);
        }
    }
}
