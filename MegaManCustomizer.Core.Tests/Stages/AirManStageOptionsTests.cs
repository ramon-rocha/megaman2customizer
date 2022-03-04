using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests;

public class AirManStageOptionsTests
{
    private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

    [Fact]
    public void StageNameLine1_IsAir()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(" AIR  ", rom.Stages.AirMan.NameLine1);
    }

    [Fact]
    public void StageNameLine2_IsMan()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("   MAN", rom.Stages.AirMan.NameLine2);
    }

    [Fact]
    public void StageName_IsAirMan()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(" AIR  \n   MAN", rom.Stages.AirMan.Name);
    }

    [Theory]
    [InlineData("AIR\nMAN", " AIR  ", "   MAN")]
    [InlineData("AIR\rMAN", " AIR  ", "   MAN")]
    [InlineData("AIR\r\nMAN", " AIR  ", "   MAN")]
    [InlineData("AIR\n\n\nMAN", " AIR  ", "   MAN")]
    [InlineData("AIR\nWOMAN", "AIR   ", " WOMAN")]
    [InlineData("A\nB", "   A  ", "   B  ")]
    [InlineData("A\nBB", "  A   ", "  BB  ")]
    [InlineData("A\nBBB", "  A   ", "  BBB ")]
    [InlineData("A\nBBBB", " A    ", " BBBB ")]
    [InlineData("AA\nB", "  AA  ", "   B  ")]
    [InlineData("AA\nBB", "  AA  ", "   BB ")]
    [InlineData("AA\nBBB", " AA   ", "  BBB ")]
    [InlineData("AA\nBBBB", " AA   ", "  BBBB")]
    [InlineData("AAA\nB", " AAA  ", "   B  ")]
    [InlineData("AAA\nBB", " AAA  ", "   BB ")]
    [InlineData("AAA\nBBBB", "AAA   ", "  BBBB")]
    [InlineData("AAAA\nB", " AAAA ", "    B ")]
    [InlineData("AAAA\nBB", "AAAA  ", "   BB ")]

    public void SettingStageName_SplitsOnLineBreak_PadsWithWhiteSpace(string name, string line1, string line2)
    {
        var rom = new MegaMan2Rom(_romBytes);
        rom.Stages.AirMan.Name = name;
        Assert.Equal(line1, rom.Stages.AirMan.NameLine1);
        Assert.Equal(line2, rom.Stages.AirMan.NameLine2);
    }

    [Theory]
    [InlineData(" AIR  \n   MAN", " AIR  ", "   MAN")]
    [InlineData("   AIR\n   MAN", "   AIR", "   MAN")]
    [InlineData("AIR   \nMAN   ", "AIR   ", "MAN   ")]
    [InlineData("  AIR \n  MAN ", "  AIR ", "  MAN ")]
    [InlineData("A     \nB     ", "A     ", "B     ")]
    [InlineData("A     \nBB    ", "A     ", "BB    ")]
    [InlineData("A     \nBBB   ", "A     ", "BBB   ")]
    [InlineData("A     \nBBBB  ", "A     ", "BBBB  ")]
    [InlineData("AA    \nB     ", "AA    ", "B     ")]
    [InlineData("AA    \nBB    ", "AA    ", "BB    ")]
    [InlineData("AA    \nBBB   ", "AA    ", "BBB   ")]
    [InlineData("AA    \nBBBB  ", "AA    ", "BBBB  ")]
    [InlineData("AAA   \nB     ", "AAA   ", "B     ")]
    [InlineData("AAA   \nBB    ", "AAA   ", "BB    ")]
    [InlineData("AAA   \nBBBB  ", "AAA   ", "BBBB  ")]
    [InlineData("AAAA  \nB     ", "AAAA  ", "B     ")]
    [InlineData("AAAA  \nBB    ", "AAAA  ", "BB    ")]
    public void SettingStageName_PreservesGivenWhiteSpace(string name, string line1, string line2)
    {
        var rom = new MegaMan2Rom(_romBytes);
        rom.Stages.AirMan.Name = name;
        Assert.Equal(line1, rom.Stages.AirMan.NameLine1);
        Assert.Equal(line2, rom.Stages.AirMan.NameLine2);
    }

    [Fact]
    public void SkyColor_IsLightBlue()
    {
        var rom = new MegaMan2Rom(_romBytes);
        var lightBlue = new Color(Chrominance.Blue, Luma.Light);
        Assert.Equal(lightBlue, rom.Stages.AirMan.SkyColor);
    }

    [Fact]
    public void CloudColor_IsWhite()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(Color.White, rom.Stages.AirMan.CloudColor);
    }

    [Fact]
    public void CloudOuterBorderColor_IsLightBlue()
    {
        var rom = new MegaMan2Rom(_romBytes);
        var lightBlue = new Color(Chrominance.Blue, Luma.Light);
        Assert.Equal(lightBlue, rom.Stages.AirMan.CloudOuterBorderColor);
    }

    [Fact]
    public void CloudInnerBorderColor_IsVeryLightBlue()
    {
        var rom = new MegaMan2Rom(_romBytes);
        var veryLightBlue = new Color(Chrominance.Blue, Luma.VeryLight);
        Assert.Equal(veryLightBlue, rom.Stages.AirMan.CloudInnerBorderColor);
    }

    [Theory]
    [InlineData(Addresses.AirStageCloudOuterBorderColorFrame0, "Light Blue")]
    [InlineData(Addresses.AirStageCloudOuterBorderColorFrame1, "Light Blue")]
    [InlineData(Addresses.AirStageCloudOuterBorderColorFrame2, "Very Light Blue")]
    [InlineData(Addresses.AirStageCloudOuterBorderColorFrame3, "White")]
    [InlineData(Addresses.AirStageCloudOuterBorderColorFrame4, "Very Light Blue")]
    public void CloudOuterBorderColor_Pulses(int address, string colorName)
    {
        var expectedColor = Color.Parse(colorName);
        var actualColor = new Color(_romBytes[address]);
        Assert.Equal(expectedColor, actualColor);
    }

    [Theory]
    [InlineData(Addresses.AirStageCloudInnerBorderColorFrame0, "Very Light Blue")]
    [InlineData(Addresses.AirStageCloudInnerBorderColorFrame1, "Very Light Blue")]
    [InlineData(Addresses.AirStageCloudInnerBorderColorFrame2, "White")]
    [InlineData(Addresses.AirStageCloudInnerBorderColorFrame3, "White")]
    [InlineData(Addresses.AirStageCloudInnerBorderColorFrame4, "White")]
    public void CloudInnerBorderColor_Pulses(int address, string colorName)
    {
        var expectedColor = Color.Parse(colorName);
        var actualColor = new Color(_romBytes[address]);
        Assert.Equal(expectedColor, actualColor);
    }

    [Theory]
    [InlineData("Red", "Very Light Violet", "Orange", "Yellow")]
    [InlineData("Black", "Gray", "Dark Violet", "Dark Indigo")]
    public void ChangingSkyAndCloudColors_ChangesPulsedColors(string sky, string cloud, string outerBorder, string innerBorder)
    {
        var rom = new MegaMan2Rom(_romBytes);
        var stage = rom.Stages.AirMan;
        stage.SkyColor = Color.Parse(sky);
        stage.CloudColor = Color.Parse(cloud);
        stage.CloudOuterBorderColor = Color.Parse(outerBorder);
        stage.CloudInnerBorderColor = Color.Parse(innerBorder);

        Assert.Equal(sky, stage.SkyColor.Name);
        Assert.Equal(cloud, stage.CloudColor.Name);
        Assert.Equal(outerBorder, stage.CloudOuterBorderColor.Name);
        Assert.Equal(innerBorder, stage.CloudInnerBorderColor.Name);

        Assert.Equal(innerBorder, new Color(rom.Bytes[Addresses.AirStageCloudInnerBorderColorFrame0]).Name);
        Assert.Equal(innerBorder, new Color(rom.Bytes[Addresses.AirStageCloudInnerBorderColorFrame1]).Name);
        Assert.Equal(cloud, new Color(rom.Bytes[Addresses.AirStageCloudInnerBorderColorFrame2]).Name);
        Assert.Equal(cloud, new Color(rom.Bytes[Addresses.AirStageCloudInnerBorderColorFrame3]).Name);
        Assert.Equal(cloud, new Color(rom.Bytes[Addresses.AirStageCloudInnerBorderColorFrame4]).Name);

        Assert.Equal(outerBorder, new Color(rom.Bytes[Addresses.AirStageCloudOuterBorderColorFrame0]).Name);
        Assert.Equal(outerBorder, new Color(rom.Bytes[Addresses.AirStageCloudOuterBorderColorFrame1]).Name);
        Assert.Equal(innerBorder, new Color(rom.Bytes[Addresses.AirStageCloudOuterBorderColorFrame2]).Name);
        Assert.Equal(cloud, new Color(rom.Bytes[Addresses.AirStageCloudOuterBorderColorFrame3]).Name);
        Assert.Equal(innerBorder, new Color(rom.Bytes[Addresses.AirStageCloudOuterBorderColorFrame4]).Name);
    }
}
