namespace MegaMan2Customizer.Core
{

    public class BubbleManOptions : BaseRobotMasterOptions
    {
        public BubbleManOptions(byte[] romBytes) : base(romBytes, Addresses.BubbleManColor1, Addresses.BubbleManColor2)
        {
        }
    }
}