using System;
using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests;

public class AirShooterOptionsTests
{
    private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

    [Fact]
    public void PrimaryColor_IsWhite()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("White", rom.Weapons.AirShooter.PrimaryColor.Name);
    }

    [Fact]
    public void SecondaryColor_IsBlue()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("Blue", rom.Weapons.AirShooter.SecondaryColor.Name);
    }

    [Fact]
    public void DefaultWeaponId()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(WeaponId.AirShooter, rom.Weapons.AirShooter.WeaponId);
    }

    [Fact]
    public void ChangeAirShooterName()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal("AIR SHOOTER", rom.Weapons.AirShooter.Name);
        Assert.Equal('A', rom.Weapons.AirShooter.LetterCode);
        Assert.Throws<ArgumentException>(() => rom.Weapons.AirShooter.Name = "");
        Assert.Throws<ArgumentException>(() => rom.Weapons.AirShooter.Name = "THIS NAME IS WAY TOO LONG!");
        rom.Weapons.AirShooter.Name = "TORNADO BLAST";
        rom.Weapons.AirShooter.LetterCode = 'T';
        Assert.Equal("TORNADO BLAST", rom.Weapons.AirShooter.Name);
        Assert.Equal('T', rom.Weapons.AirShooter.LetterCode);
        Assert.Equal(" TORNADO BLAST", Text.DecodeCutScene(rom.Bytes, Addresses.AirShooterName));
    }

    [Fact]
    public void DefaultProjectileCount_Is3()
    {
        var rom = new MegaMan2Rom(_romBytes);
        Assert.Equal(3, rom.Weapons.AirShooter.ProjectileCount);
    }
}
