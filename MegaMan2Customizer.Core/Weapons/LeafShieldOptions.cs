namespace MegaMan2Customizer.Core;

public class LeafShieldOptions : BaseWeaponOptions
{
    public byte DeployDelay
    {
        get => _romBytes[Addresses.LeafShieldDeployDelay];
        set => _romBytes[Addresses.LeafShieldDeployDelay] = value;
    }

    public byte HorizontalSpeed
    {
        get => _romBytes[Addresses.LeafShieldHorizSpeed];
        set => _romBytes[Addresses.LeafShieldHorizSpeed] = value;
    }

    public byte VerticalSpeed
    {
        get => _romBytes[Addresses.LeafShieldVertSpeed];
        set => _romBytes[Addresses.LeafShieldVertSpeed] = value;
    }

    public byte AmmoUsed
    {
        get => _romBytes[Addresses.LeafShieldAmmoUsed];
        set => _romBytes[Addresses.LeafShieldAmmoUsed] = value;
    }

    public LeafShieldOptions(byte[] romBytes) : base(
        romBytes,
        primaryColorAddress: Addresses.LeafShieldColor1,
        secondaryColorAddress: Addresses.LeafShieldColor2,
        weaponNameAddress: Addresses.LeafShieldName,
        cutSceneLetterAddress: Addresses.LeafShieldCutSceneLetterCode,
        menuLetterAddress: Addresses.LeafShieldMenuLetterCode,
        weaponId: WeaponId.LeafShield)
    {
    }
}
