﻿using System;

namespace MegaMan2Customizer.Core;

public class AllWeaponOptions
{
    public AirShooterOptions AirShooter { get; }

    public AtomicFireOptions AtomicFire { get; }

    public BubbleLeadOptions BubbleLead { get; }

    public CrashBomberOptions CrashBomber { get; }

    public LeafShieldOptions LeafShield { get; }

    public MetalBladeOptions MetalBlade { get; }

    public QuickBoomerangOptions QuickBoomerang { get; }

    public TimeStopperOptions TimeStopper { get; }

    public AllWeaponOptions(byte[] romBytes)
    {
        this.AirShooter = new AirShooterOptions(romBytes);
        this.AtomicFire = new AtomicFireOptions(romBytes);
        this.BubbleLead = new BubbleLeadOptions(romBytes);
        this.CrashBomber = new CrashBomberOptions(romBytes);
        this.LeafShield = new LeafShieldOptions(romBytes);
        this.MetalBlade = new MetalBladeOptions(romBytes);
        this.QuickBoomerang = new QuickBoomerangOptions(romBytes);
        this.TimeStopper = new TimeStopperOptions(romBytes);
    }

    public IWeaponOptions GetWeaponOptions(WeaponId weaponId) => weaponId switch
    {
        WeaponId.AtomicFire => this.AtomicFire,
        WeaponId.AirShooter => this.AirShooter,
        WeaponId.LeafShield => this.LeafShield,
        WeaponId.BubbleLead => this.BubbleLead,
        WeaponId.QuickBoomerang => this.QuickBoomerang,
        WeaponId.TimeStopper => this.TimeStopper,
        WeaponId.MetalBlade => this.MetalBlade,
        WeaponId.CrashBomber => this.CrashBomber,
        _ => throw new Exception($"Unhandled value '{weaponId}' for {nameof(weaponId)}"),
    };
}
