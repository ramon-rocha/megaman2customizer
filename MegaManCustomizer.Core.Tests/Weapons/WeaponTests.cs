using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class WeaponTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [InlineData(WeaponId.AtomicFire, "ATOMIC FIRE", 'H')]
        [InlineData(WeaponId.AirShooter, "AIR SHOOTER", 'A')]
        [InlineData(WeaponId.LeafShield, "LEAF SHIELD", 'W')]
        [InlineData(WeaponId.BubbleLead, "BUBBLE-LEAD", 'B')]
        [InlineData(WeaponId.QuickBoomerang, "QUICK-BOOMERANG", 'Q')]
        [InlineData(WeaponId.TimeStopper, "TIME-STOPPER", 'F')]
        [InlineData(WeaponId.MetalBlade, "METAL-BLADE", 'M')]
        [InlineData(WeaponId.CrashBomb, "CRASH BOMBER", 'C')]
        [Theory]
        public void DefaultNamesAndLetterCodes(WeaponId weaponId, string name, char letterCode)
        {
            var rom = new MegaManRom(_romBytes);
            IWeaponOptions weaponOptions = rom.Weapons.GetWeaponOptions(weaponId);
            Assert.Equal(weaponId, weaponOptions.WeaponId);
            Assert.Equal(name, weaponOptions.Name);
            Assert.Equal(letterCode, weaponOptions.LetterCode);
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
