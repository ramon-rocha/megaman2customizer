namespace MegaMan2Customizer.Core.Items;

public class Item2Options : BaseItemOptions
{
    public Item2Options(byte[] romBytes) : base(romBytes, Addresses.Item2Color1, Addresses.Item2Color2, ItemId.Item2)
    {
    }
}
