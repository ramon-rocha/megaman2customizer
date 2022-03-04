namespace MegaMan2Customizer.Core;

public class HeatManOptions : BaseRobotMasterOptions
{
    public Color ProjectileColor1
    {
        get => new(_romBytes[Addresses.HeatManProjectileColor1]);
        set => _romBytes[Addresses.HeatManProjectileColor1] = value.Value;
    }

    public Color ProjectileColor2
    {
        get => new(_romBytes[Addresses.HeatManProjectileColor2]);
        set => _romBytes[Addresses.HeatManProjectileColor2] = value.Value;
    }

    public byte Projectile1Height
    {
        get => _romBytes[Addresses.HeatManProjectile1Height];
        set => _romBytes[Addresses.HeatManProjectile1Height] = value;
    }

    public byte Projectile1Distance
    {
        get => _romBytes[Addresses.HeatManProjectile1Distance];
        set => _romBytes[Addresses.HeatManProjectile1Distance] = value;
    }

    public byte Projectile2Height
    {
        get => _romBytes[Addresses.HeatManProjectile2Height];
        set => _romBytes[Addresses.HeatManProjectile2Height] = value;
    }

    public byte Projectile2Distance
    {
        get => _romBytes[Addresses.HeatManProjectile2Distance];
        set => _romBytes[Addresses.HeatManProjectile2Distance] = value;
    }

    public byte Projectile3Height
    {
        get => _romBytes[Addresses.HeatManProjectile3Height];
        set => _romBytes[Addresses.HeatManProjectile3Height] = value;
    }

    public byte Projectile3Distance
    {
        get => _romBytes[Addresses.HeatManProjectile3Distance];
        set => _romBytes[Addresses.HeatManProjectile3Distance] = value;
    }

    public byte RushDelay1
    {
        get => _romBytes[Addresses.HeatManRushDelay1];
        set => _romBytes[Addresses.HeatManRushDelay1] = value;
    }

    public byte RushDelay2
    {
        get => _romBytes[Addresses.HeatManRushDelay2];
        set => _romBytes[Addresses.HeatManRushDelay2] = value;
    }

    public byte RushDelay3
    {
        get => _romBytes[Addresses.HeatManRushDelay3];
        set => _romBytes[Addresses.HeatManRushDelay3] = value;
    }

    public byte RushSpeed
    {
        get => _romBytes[Addresses.HeatManRushSpeed];
        set => _romBytes[Addresses.HeatManRushSpeed] = value;
    }

    public HeatManOptions(byte[] romBytes) : base(romBytes, Addresses.HeatManColor1, Addresses.HeatManColor2, Addresses.HeatManWeaponOnDefeat, Addresses.HeatManItemOnDefeat)
    {
    }
}
