using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class MegaManOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void StartingHealth_Is28()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(28, rom.MegaMan.StartingHealth);
        }

        [Fact]
        public void BusterPrimaryColor_IsCyan()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Light Cyan", rom.MegaMan.BusterPrimaryColor.Name);
        }

        [Fact]
        public void BusterPrimaryColor_IsBlue()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Blue", rom.MegaMan.BusterSecondaryColor.Name);
        }

        [Fact]
        public void MaxBusterShots_Is4()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(4, rom.MegaMan.MaxBusterShots);
        }

        [Fact]
        public void BusterSpeed_Is4()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(4, rom.MegaMan.BusterSpeed);
        }

        [Fact]
        public void Speed_Is1()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(1, rom.MegaMan.Speed);
        }

        [Fact]
        public void LadderClimbSpeed_IsPoint75()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(0.75m, rom.MegaMan.LadderClimbSpeed);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("0.5")]
        [InlineData("1.0")]
        [InlineData("1.5")]
        [InlineData("2.0")]
        public void LadderClimbSpeed_CanBeChanged(string valueText)
        {
            var value = decimal.Parse(valueText);
            var rom = new MegaManRom(_romBytes);
            rom.MegaMan.LadderClimbSpeed = value;
            Assert.Equal(value, rom.MegaMan.LadderClimbSpeed);
        }

        [Fact]
        public void LadderDescentSpeed_Is255Point25()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(255.25m, rom.MegaMan.LadderDescentSpeed);
        }

        [Fact]
        public void JumpHeight_Is4()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(4, rom.MegaMan.JumpHeight);
        }

        [Theory]
        [InlineData(0x00)]
        [InlineData(1)]
        [InlineData(14)]
        [InlineData(28)]
        [InlineData(0xFF)]
        public void CanChange_StartingHealth(byte startingHealth)
        {
            var rom = new MegaManRom(_romBytes);
            rom.MegaMan.StartingHealth = startingHealth;
            string path = "";
            try
            {
                path = Path.GetTempFileName();
                rom.SaveAs(path);
                var modifiedRom = new MegaManRom(path);
                Assert.Equal(startingHealth, rom.MegaMan.StartingHealth);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
