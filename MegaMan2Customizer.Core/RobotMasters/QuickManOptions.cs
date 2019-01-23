namespace MegaMan2Customizer.Core
{
    public class QuickManOptions : BaseRobotMasterOptions
    {
        public QuickManOptions(byte[] romBytes) : base(romBytes, Addresses.QuickManColor1, Addresses.QuickManColor2)
        {
        }
    }
}