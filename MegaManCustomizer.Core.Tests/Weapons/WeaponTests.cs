using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests;

public class WeaponTests
{
    private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

    [Theory]
    [InlineData(WeaponId.AtomicFire, "ATOMIC FIRE", 'H')]
    [InlineData(WeaponId.AirShooter, "AIR SHOOTER", 'A')]
    [InlineData(WeaponId.LeafShield, "LEAF SHIELD", 'W')]
    [InlineData(WeaponId.BubbleLead, "BUBBLE-LEAD", 'B')]
    [InlineData(WeaponId.QuickBoomerang, "QUICK-BOOMERANG", 'Q')]
    [InlineData(WeaponId.TimeStopper, "TIME-STOPPER", 'F')]
    [InlineData(WeaponId.MetalBlade, "METAL-BLADE", 'M')]
    [InlineData(WeaponId.CrashBomber, "CRASH BOMBER", 'C')]
    public void DefaultNamesAndLetterCodes(WeaponId weaponId, string name, char letterCode)
    {
        var rom = new MegaMan2Rom(_romBytes);
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

    [Theory]
    [InlineData(WeaponId.AtomicFire, "Yellow", "Crimson")]
    [InlineData(WeaponId.AirShooter, "White", "Blue")]
    [InlineData(WeaponId.LeafShield, "White", "Sea Green")]
    [InlineData(WeaponId.BubbleLead, "White", "Darker Gray")]
    [InlineData(WeaponId.QuickBoomerang, "Very Light Magenta", "Light Crimson")]
    [InlineData(WeaponId.TimeStopper, "Very Light Magenta", "Magenta")]
    [InlineData(WeaponId.MetalBlade, "Very Light Orange", "Dark Yellow")]
    [InlineData(WeaponId.CrashBomber, "White", "Light Red")]
    public void DefaultWeaponColors(WeaponId weaponId, string primaryColor, string secondaryColor)
    {
        var rom = new MegaMan2Rom(_romBytes);
        IWeaponOptions weaponOptions = rom.Weapons.GetWeaponOptions(weaponId);
        Assert.Equal(weaponId, weaponOptions.WeaponId);
        Assert.Equal(primaryColor, weaponOptions.PrimaryColor.Name);
        Assert.Equal(secondaryColor, weaponOptions.SecondaryColor.Name);
    }
}
