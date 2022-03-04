namespace MegaMan2Customizer.Core;

public class StartMenuOptions
{
    private readonly byte[] _romBytes;

    public Color BorderColor
    {
        get => new(_romBytes[Addresses.StartMenuBorderColor]);
        set => _romBytes[Addresses.StartMenuBorderColor] = value.Value;
    }

    public Color BackgroundColor
    {
        get => new(_romBytes[Addresses.StartMenuBackgroundColor]);
        set => _romBytes[Addresses.StartMenuBackgroundColor] = value.Value;
    }

    public Color ShadowColor
    {
        get => new(_romBytes[Addresses.StartMenuShadowColor]);
        set => _romBytes[Addresses.StartMenuShadowColor] = value.Value;
    }

    public StartMenuOptions(byte[] romBytes) => _romBytes = romBytes;
}
