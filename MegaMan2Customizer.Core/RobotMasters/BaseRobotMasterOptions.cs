namespace MegaMan2Customizer.Core;

public abstract class BaseRobotMasterOptions
{
    protected readonly byte[] _romBytes;

    protected readonly int _primaryColorAddress;

    protected readonly int _secondaryColorAddress;

    protected readonly int _weaponOnDefeatAddress;

    protected readonly int _itemOnDefeatAddress;

    public virtual Color PrimaryColor
    {
        get => new(_romBytes[_primaryColorAddress]);
        set => _romBytes[_primaryColorAddress] = value.Value;
    }

    public virtual Color SecondaryColor
    {
        get => new(_romBytes[_secondaryColorAddress]);
        set => _romBytes[_secondaryColorAddress] = value.Value;
    }

    public virtual WeaponId WeaponOnDefeat
    {
        get => (WeaponId)_romBytes[_weaponOnDefeatAddress];
        set => _romBytes[_weaponOnDefeatAddress] = (byte)value;
    }

    public virtual ItemId ItemOnDefeat
    {
        get => (ItemId)_romBytes[_itemOnDefeatAddress];
        set => _romBytes[_itemOnDefeatAddress] = (byte)value;
    }

    public BaseRobotMasterOptions(byte[] romBytes, int primaryColorAddress, int secondaryColorAddress, int weaponOnDefeatAddress, int itemOnDefeatAddress)
    {
        _romBytes = romBytes;
        _primaryColorAddress = primaryColorAddress;
        _secondaryColorAddress = secondaryColorAddress;
        _weaponOnDefeatAddress = weaponOnDefeatAddress;
        _itemOnDefeatAddress = itemOnDefeatAddress;
    }
}
