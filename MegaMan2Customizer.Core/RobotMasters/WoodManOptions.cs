namespace MegaMan2Customizer.Core
{
    public class WoodManOptions : BaseRobotMasterOptions
    {
        public WoodManOptions(byte[] romBytes) : base(romBytes, Addresses.WoodManColor1, Addresses.WoodManColor2)
        {
        }
    }
}