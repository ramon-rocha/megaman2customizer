using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests;

public class FlashManOptionsTests
{
    private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

    [Fact]
    public void PrimaryColor_IsWhite()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("White", rom.RobotMasters.FlashMan.PrimaryColor.Name);
    }

    [Fact]
    public void SecondaryColor_IsIndigo()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("Indigo", rom.RobotMasters.FlashMan.SecondaryColor.Name);
    }

    [Fact]
    public void RunSpeed_Is1()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(1.0234375m, rom.RobotMasters.FlashMan.RunSpeed);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("0.5")]
    [InlineData("1.0")]
    [InlineData("1.5")]
    [InlineData("2.0")]
    public void RunSpeed_CanBeChanged(string valueText)
    {
        var value = decimal.Parse(valueText);
        var rom = new MegaMan2Rom(_romBytes);
        rom.RobotMasters.FlashMan.RunSpeed = value;
        Assert.Equal(value, rom.RobotMasters.FlashMan.RunSpeed);
    }

    [Fact]
    public void JumpDistance_Is0() // TODO: include fraction
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(0, rom.RobotMasters.FlashMan.JumpDistance);
    }

    [Fact]
    public void JumpHeight_Is4()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(4, rom.RobotMasters.FlashMan.JumpHeight);
    }

    [Fact]
    public void ProjectileCount_Is6()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(6, rom.RobotMasters.FlashMan.ProjectileCount);
    }


    [Fact]
    public void ProjectileSpeed_Is8()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(8, rom.RobotMasters.FlashMan.ProjectileSpeed);
    }

    [Fact]
    public void TimeStopperDelay_Is187()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(0xBB, rom.RobotMasters.FlashMan.TimeStopperDelay);
    }
}
