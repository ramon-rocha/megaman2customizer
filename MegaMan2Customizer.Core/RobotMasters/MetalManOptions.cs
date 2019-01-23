namespace MegaMan2Customizer.Core
{
    public class MetalManOptions : BaseRobotMasterOptions
    {
        public MetalManOptions(byte[] romBytes) : base(romBytes, Addresses.MetalManColor1, Addresses.MetalManColor2)
        {
        }
    }
}