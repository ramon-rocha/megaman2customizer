namespace MegaMan2Customizer.Core
{
    public class CrashManOptions : BaseRobotMasterOptions
    {
        public CrashManOptions(byte[] romBytes) : base(romBytes, Addresses.CrashManColor1, Addresses.CrashManColor2)
        {
        }
    }
}