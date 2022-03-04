namespace MegaMan2Customizer.Core;

public class MetalBladeOptions : BaseWeaponOptions
{
    public byte MaxShots
    {
        get => _romBytes[Addresses.MetalBladeMaxshots];
        set => _romBytes[Addresses.MetalBladeMaxshots] = value;
    }

    public byte ShotsPerAmmo
    {
        get => _romBytes[Addresses.MetalBladeShotsPerAmmo];
        set => _romBytes[Addresses.MetalBladeShotsPerAmmo] = value;
    }

    public byte Speed // TODO: seperate into different directions
    {
        get => _romBytes[Addresses.MetalBladeHorizSpeed];
        set
        {
            _romBytes[Addresses.MetalBladeHorizSpeed] = value;
            _romBytes[Addresses.MetalBladeHorizSpeedLeft] = value;
            _romBytes[Addresses.MetalBladeHorizSpeedRight] = value;
            _romBytes[Addresses.MetalBladeVertSpeedDown] = value;
            _romBytes[Addresses.MetalBladeVertSpeedUp] = value;
            byte diagonalSpeed = (byte)(value == 1 ? 1 : value / 2);
            _romBytes[Addresses.MetalBladeVertSpeedUpRight] = diagonalSpeed;
            _romBytes[Addresses.MetalBladeVertSpeedDownRight] = diagonalSpeed;
            _romBytes[Addresses.MetalBladeVertSpeedDownLeft] = diagonalSpeed;
            _romBytes[Addresses.MetalBladeVertSpeedUpLeft] = diagonalSpeed;
        }
    }

    public MetalBladeOptions(byte[] romBytes) : base(
        romBytes,
        primaryColorAddress: Addresses.MetalBladeColor1,
        secondaryColorAddress: Addresses.MetalBladeColor2,
        weaponNameAddress: Addresses.MetalBladeName,
        cutSceneLetterAddress: Addresses.MetalBladeCutSceneLetterCode,
        menuLetterAddress: Addresses.MetalBladeCutMenuCode,
        weaponId: WeaponId.MetalBlade)
    {
    }
}
