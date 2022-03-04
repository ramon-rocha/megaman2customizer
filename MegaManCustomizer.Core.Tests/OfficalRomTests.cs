using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests;

public class OfficialRomTests
{
    private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

    [Fact]
    public void MegaManOptions_StartingHealth_IsDefault28()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(28, rom.MegaMan.StartingHealth);
    }

    [Fact]
    public void MegaManOptions_MaxHealth_IsDefault28()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(28, rom.MegaMan.MaxHealth);
    }

    [Fact]
    public void MenuOptions_DefaultColors()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(new Color(Chrominance.Crimson, Luma.VeryLight), rom.StartMenu.BorderColor);
        Assert.Equal(new Color(Chrominance.Blue, Luma.Light), rom.StartMenu.BackgroundColor);
        Assert.Equal(new Color(Chrominance.Blue, Luma.Medium), rom.StartMenu.ShadowColor);
    }
}
