using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class AtomicFireOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void PrimaryColor_IsBrightYellow()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Bright Yellow", rom.WeaponOptions.AtomicFire.PrimaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_IsCrimson()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Crimson", rom.WeaponOptions.AtomicFire.SecondaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_AlsoSetsChargeColors()
        {
            Color charge1Color, charge2Color;

            var rom = new MegaManRom(_romBytes);
            var atomicFire = rom.WeaponOptions.AtomicFire;
            charge1Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor1]);
            charge2Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor2]);
            Assert.NotEqual("Bright White", atomicFire.SecondaryColor.Name);
            Assert.NotEqual("Bright White", charge1Color.Name);
            Assert.NotEqual("Bright White", charge2Color.Name);

            atomicFire.SecondaryColor = new Color(Pigment.White, Brightness.Bright);
            charge1Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor1]);
            charge2Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor2]);
            Assert.Equal("Bright White", atomicFire.SecondaryColor.Name);
            Assert.Equal("Bright White", charge1Color.Name);
            Assert.Equal("Bright White", charge2Color.Name);
        }
    }
}
