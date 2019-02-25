using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class AtomicFireOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void PrimaryColor_IsYellow()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Yellow", rom.Weapons.AtomicFire.PrimaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_IsCrimson()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Crimson", rom.Weapons.AtomicFire.SecondaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_AlsoSetsChargeColors()
        {
            Color charge1Color, charge2Color;

            var rom = new MegaManRom(_romBytes);
            var atomicFire = rom.Weapons.AtomicFire;
            charge1Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor1]);
            charge2Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor2]);
            Assert.NotEqual("White", atomicFire.SecondaryColor.Name);
            Assert.NotEqual("White", charge1Color.Name);
            Assert.NotEqual("White", charge2Color.Name);

            atomicFire.SecondaryColor = Color.White;
            charge1Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor1]);
            charge2Color = new Color(rom.Bytes[Addresses.AtomicFireChargeColor2]);
            Assert.Equal("White", atomicFire.SecondaryColor.Name);
            Assert.Equal("White", charge1Color.Name);
            Assert.Equal("White", charge2Color.Name);
        }

        [Fact]
        public void DefaultWeaponId()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(WeaponId.AtomicFire, rom.Weapons.AtomicFire.WeaponId);
        }
    }
}
