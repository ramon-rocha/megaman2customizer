using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class WeaponTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void DefaultNamesAndLetterCodes()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("ATOMIC FIRE", rom.Weapons.AtomicFire.Name);
            Assert.Equal('H', rom.Weapons.AtomicFire.LetterCode);
            Assert.Equal("AIR SHOOTER", rom.Weapons.AirShooter.Name);
            Assert.Equal('A', rom.Weapons.AirShooter.LetterCode);
            Assert.Equal("LEAF SHIELD", rom.Weapons.LeafShield.Name);
            Assert.Equal('W', rom.Weapons.LeafShield.LetterCode);
            Assert.Equal("BUBBLE-LEAD", rom.Weapons.BubbleLead.Name);
            Assert.Equal('B', rom.Weapons.BubbleLead.LetterCode);
            Assert.Equal("QUICK-BOOMERANG", rom.Weapons.QuickBoomerang.Name);
            Assert.Equal('Q', rom.Weapons.QuickBoomerang.LetterCode);
            Assert.Equal("TIME-STOPPER", rom.Weapons.TimeStopper.Name);
            Assert.Equal('F', rom.Weapons.TimeStopper.LetterCode);
            Assert.Equal("METAL-BLADE", rom.Weapons.MetalBlade.Name);
            Assert.Equal('M', rom.Weapons.MetalBlade.LetterCode);
            Assert.Equal("CRASH BOMBER", rom.Weapons.CrashBomber.Name);
            Assert.Equal('C', rom.Weapons.CrashBomber.LetterCode);
        }

        [Fact]
        public void WeaponLetterCodes_IntersectsTwoEncodings()
        {
            IReadOnlyList<char> letterCodes = Text.WeaponLetterCodes;
            Assert.All(letterCodes, c => char.IsLetterOrDigit(c));
            Assert.Contains('A', letterCodes);
            Assert.Contains('0', letterCodes);
            Assert.Contains('9', letterCodes);
            Assert.DoesNotContain('D', letterCodes);
            Assert.DoesNotContain('Y', letterCodes);
            Assert.DoesNotContain('Z', letterCodes);
        }
    }
}
