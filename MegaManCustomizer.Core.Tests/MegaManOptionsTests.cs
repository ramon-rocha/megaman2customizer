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
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(28, rom.MegaMan.StartingHealth);
        }

        [Fact]
        public void BusterPrimaryColor_IsCyan()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal("Light Cyan", rom.MegaMan.BusterPrimaryColor.Name);
        }

        [Fact]
        public void BusterPrimaryColor_IsBlue()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal("Blue", rom.MegaMan.BusterSecondaryColor.Name);
        }

        [Fact]
        public void BusterLetterCode_IsP()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal('P', rom.MegaMan.BusterLetterCode);
        }

        [Fact]
        public void BusterLetterCode_CanBeChanged()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal('P', rom.MegaMan.BusterLetterCode);
            rom.MegaMan.BusterLetterCode = 'M';
            Assert.Equal('M', rom.MegaMan.BusterLetterCode);
        }

        [Fact]
        public void MaxBusterShots_Is3()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(3, rom.MegaMan.MaxBusterShots);
        }

        [Fact]
        public void BusterSpeed_Is4()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(4, rom.MegaMan.BusterSpeed);
        }

        [Fact]
        public void Speed_Is1()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(1, rom.MegaMan.Speed);
        }

        [Fact]
        public void LadderClimbSpeed_IsPoint75()
        {
            var rom = new MegaMan2Rom(_romBytes);
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
            var rom = new MegaMan2Rom(_romBytes);
            rom.MegaMan.LadderClimbSpeed = value;
            Assert.Equal(value, rom.MegaMan.LadderClimbSpeed);
        }

        [Fact]
        public void LadderDescentSpeed_Is255Point25()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(255.25m, rom.MegaMan.LadderDescentSpeed);
        }

        [Fact]
        public void JumpHeight_Is4()
        {
            var rom = new MegaMan2Rom(_romBytes);
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
            var rom = new MegaMan2Rom(_romBytes);
            rom.MegaMan.StartingHealth = startingHealth;
            string path = "";
            try
            {
                path = Path.GetTempFileName();
                rom.SaveAs(path);
                var modifiedRom = new MegaMan2Rom(path);
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

        [Fact]
        public void ChangingBusterColor_ChangesMultipleLocations()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal("Light Cyan", new Color(rom.Bytes[Addresses.BusterColor1]).Name);
            Assert.Equal("Blue", new Color(rom.Bytes[Addresses.BusterColor2]).Name);
            Assert.Equal("Light Cyan", new Color(rom.Bytes[Addresses.BusterColor1CutScene]).Name);
            Assert.Equal("Light Cyan", new Color(rom.Bytes[Addresses.BusterColor1CutSceneBoots]).Name);
            Assert.Equal("Blue", new Color(rom.Bytes[Addresses.BusterColor2CutScene]).Name);
            Assert.Equal("Blue", new Color(rom.Bytes[Addresses.BusterColor2CutSceneBoots]).Name);
            Assert.Equal("Light Cyan", new Color(rom.Bytes[Addresses.BusterColor1TitleScreen]).Name);
            Assert.Equal("Blue", new Color(rom.Bytes[Addresses.BusterColor2TitleScreen]).Name);

            rom.MegaMan.BusterPrimaryColor = new Color(Chrominance.Black, Luma.Medium);
            rom.MegaMan.BusterSecondaryColor = new Color(Chrominance.Red, Luma.Dark);

            Assert.Equal("Black", new Color(rom.Bytes[Addresses.BusterColor1]).Name);
            Assert.Equal("Dark Red", new Color(rom.Bytes[Addresses.BusterColor2]).Name);
            Assert.Equal("Black", new Color(rom.Bytes[Addresses.BusterColor1CutScene]).Name);
            Assert.Equal("Black", new Color(rom.Bytes[Addresses.BusterColor1CutSceneBoots]).Name);
            Assert.Equal("Dark Red", new Color(rom.Bytes[Addresses.BusterColor2CutScene]).Name);
            Assert.Equal("Dark Red", new Color(rom.Bytes[Addresses.BusterColor2CutSceneBoots]).Name);
            Assert.Equal("Black", new Color(rom.Bytes[Addresses.BusterColor1TitleScreen]).Name);
            Assert.Equal("Dark Red", new Color(rom.Bytes[Addresses.BusterColor2TitleScreen]).Name);

            // TODO: Find addresses for final cut scene at end of game
        }
    }
}
