namespace MegaMan2Customizer.Core;

public class FlashManOptions : BaseRobotMasterOptions
{
    public decimal RunSpeed
    {
        get => _romBytes.GetDecimal(Addresses.FlashManRunSpeedWhole, Addresses.FlashManRunSpeedFraction);
        set => _romBytes.SetDecimal(Addresses.FlashManRunSpeedWhole, Addresses.FlashManRunSpeedFraction, value);
    }

    public byte TimeStopperDelay
    {
        get => _romBytes[Addresses.FlashManTimeStopperDelay];
        set => _romBytes[Addresses.FlashManTimeStopperDelay] = value;
    }

    public byte JumpDistance
    {
        get => _romBytes[Addresses.FlashManJumpDistance];
        set => _romBytes[Addresses.FlashManJumpDistance] = value;
    }

    public byte JumpHeight
    {
        get => _romBytes[Addresses.FlashManJumpHeight];
        set => _romBytes[Addresses.FlashManJumpHeight] = value;
    }

    public byte ProjectileSpeed
    {
        get => _romBytes[Addresses.FlashManProjectileSpeed];
        set => _romBytes[Addresses.FlashManProjectileSpeed] = value;
    }

    public byte ProjectileCount
    {
        get => _romBytes[Addresses.FlashManProjectileCount];
        set => _romBytes[Addresses.FlashManProjectileCount] = value;
    }

    public FlashManOptions(byte[] romBytes) : base(romBytes, Addresses.FlashManColor1, Addresses.FlashManColor2, Addresses.FlashManWeaponOnDefeat, Addresses.FlashManItemOnDefeat)
    {
    }
}
