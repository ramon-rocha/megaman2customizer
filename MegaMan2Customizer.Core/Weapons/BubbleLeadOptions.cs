namespace MegaMan2Customizer.Core;

public class BubbleLeadOptions : BaseWeaponOptions
{
    public byte HorizontalSpeed
    {
        get => _romBytes[Addresses.BubbleLeadHorizSpeed];
        set => _romBytes[Addresses.BubbleLeadHorizSpeed] = value;
    }

    public byte SurfaceSpeed
    {
        get => _romBytes[Addresses.BubbleLeadSurfaceSpeed];
        set => _romBytes[Addresses.BubbleLeadSurfaceSpeed] = value;
    }

    public byte HorizontalFallSpeed
    {
        get => _romBytes[Addresses.BubbleLeadHorizFallSpeed];
        set => _romBytes[Addresses.BubbleLeadHorizFallSpeed] = value;
    }

    public byte VerticalFallSpeed
    {
        get => _romBytes[Addresses.BubbleLeadVertFallSpeed];
        set => _romBytes[Addresses.BubbleLeadVertFallSpeed] = value;
    }

    public byte VerticalSpeed
    {
        get => _romBytes[Addresses.BubbleLeadVertSpeed];
        set => _romBytes[Addresses.BubbleLeadVertSpeed] = value;
    }

    public byte MaxProjectiles
    {
        get => (byte)(_romBytes[Addresses.BubbleLeadMaxShots] - 1);
        set => _romBytes[Addresses.BubbleLeadMaxShots] = (byte)(value + 1);
    }

    public byte ShotsPerAmmo
    {
        get => _romBytes[Addresses.BubbleLeadShotsPerAmmo];
        set => _romBytes[Addresses.BubbleLeadShotsPerAmmo] = value;
    }

    public BubbleLeadOptions(byte[] romBytes) : base(
        romBytes,
        primaryColorAddress: Addresses.BubbleLeadColor1,
        secondaryColorAddress: Addresses.BubbleLeadColor2,
        weaponNameAddress: Addresses.BubbleLeadName,
        cutSceneLetterAddress: Addresses.BubbleLeadCutSceneLetterCode,
        menuLetterAddress: Addresses.BubbleLeadMenuLetterCode,
        weaponId: WeaponId.BubbleLead)
    {
    }
}
