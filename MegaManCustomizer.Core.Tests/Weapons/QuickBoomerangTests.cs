using System;
using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests;

public class QuickBoomerangTests
{
    private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

    [Fact]
    public void PrimaryColor_IsVeryLightMagenta()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("Very Light Magenta", rom.Weapons.QuickBoomerang.PrimaryColor.Name);
    }

    [Fact]
    public void SecondaryColor_IsLightCrimson()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("Light Crimson", rom.Weapons.QuickBoomerang.SecondaryColor.Name);
    }

    [Fact]
    public void DefaultWeaponId()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(WeaponId.QuickBoomerang, rom.Weapons.QuickBoomerang.WeaponId);
    }

    [Fact]
    public void ChangeName_SplitsOnTwoLinesWhenRequired()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("QUICK-BOOMERANG", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal('Q', rom.Weapons.QuickBoomerang.LetterCode);
        Assert.Equal("  QUICK       ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  -BOOMERANG  ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));
        Assert.Throws<ArgumentException>(() => rom.Weapons.QuickBoomerang.Name = "");
        Assert.Throws<ArgumentException>(() => rom.Weapons.QuickBoomerang.Name = "THE NAME OF QUICK-BOOMERANG NAME CAN BE EXTRA LONG BUT THIS NAME IS WAY TOO LONG!");

        rom.Weapons.QuickBoomerang.Name = "AEROBIE";
        rom.Weapons.QuickBoomerang.LetterCode = 'A';
        Assert.Equal("AEROBIE", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal('A', rom.Weapons.QuickBoomerang.LetterCode);
        Assert.Equal("  AEROBIE     ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("              ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "AEROBIE-BLADE";
        Assert.Equal("AEROBIE-BLADE", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  AEROBIE     ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  -BLADE      ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "AEROBIE BLADE";
        Assert.Equal("AEROBIE BLADE", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  AEROBIE     ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  BLADE       ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "TROPICAL THUNDERSTORM";
        rom.Weapons.QuickBoomerang.LetterCode = 'T';
        Assert.Equal("TROPICAL THUNDERSTORM", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  TROPICAL    ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  THUNDERSTORM", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "TROPICAL-THUNDERSTORM";
        Assert.Equal("TROPICAL-THUNDERSTORM", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  TROPICAL-   ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  THUNDERSTORM", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "NOSPACESANDLONGERTHAN1LINE";
        rom.Weapons.QuickBoomerang.LetterCode = 'N';
        Assert.Equal("NOSPACESANDLONGERTHAN1LINE", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal(" NOSPACESANDLO", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal(" NGERTHAN1LINE", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "NOSPACESANDLONGERTHAN1LINE!";
        Assert.Equal("NOSPACESANDLONGERTHAN1LINE!", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("NOSPACESANDLON", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal(" GERTHAN1LINE!", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "NOSPACESANDLONGERTHAN1LINE!!";
        Assert.Equal("NOSPACESANDLONGERTHAN1LINE!!", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("NOSPACESANDLON", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("GERTHAN1LINE!!", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "A SPACEANDLONGERTHAN1LINE!!!";
        Assert.Equal("A SPACEANDLONGERTHAN1LINE!!!", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("A SPACEANDLONG", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("ERTHAN1LINE!!!", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "SPACES AND-DASHES";
        Assert.Equal("SPACES AND-DASHES", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  SPACES      ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  AND-DASHES  ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "DASHES-AND SPACES";
        Assert.Equal("DASHES-AND SPACES", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  DASHES-AND  ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  SPACES      ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "MANY-MANY-DASHES";
        Assert.Equal("MANY-MANY-DASHES", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  MANY        ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  -MANY-DASHES", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "MANY-MANY-DASHES!";
        Assert.Equal("MANY-MANY-DASHES!", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  MANY-       ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  MANY-DASHES!", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "D-A-S-H-E-S";
        Assert.Equal("D-A-S-H-E-S", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  D-A-S-H-E-S ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("              ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));

        rom.Weapons.QuickBoomerang.Name = "MANY MANY SPACES";
        Assert.Equal("MANY MANY SPACES", rom.Weapons.QuickBoomerang.Name);
        Assert.Equal("  MANY        ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine1));
        Assert.Equal("  MANY SPACES ", Text.DecodeCutScene(rom.Bytes, Addresses.QuickBoomerangNameLine2));
    }
}
