namespace MegaMan2Customizer.Core;

public class CrashManOptions : BaseRobotMasterOptions
{
    public decimal WalkSpeed
    {
        get => _romBytes.GetDecimal(Addresses.CrashManWalkSpeedWhole, Addresses.CrashManWalkSpeedFraction);
        set => _romBytes.SetDecimal(Addresses.CrashManWalkSpeedWhole, Addresses.CrashManWalkSpeedFraction, value);
    }

    public byte JumpHeight
    {
        get => _romBytes[Addresses.CrashManJumpHeight];
        set => _romBytes[Addresses.CrashManJumpHeight] = value;
    }

    public byte ProjectileSpeed
    {
        get => _romBytes[Addresses.CrashManProjectileSpeed];
        set => _romBytes[Addresses.CrashManProjectileSpeed] = value;
    }

    public CrashManOptions(byte[] romBytes) : base(romBytes, Addresses.CrashManColor1, Addresses.CrashManColor2, Addresses.CrashManWeaponOnDefeat, Addresses.CrashManItemOnDefeat)
    {
    }
}
