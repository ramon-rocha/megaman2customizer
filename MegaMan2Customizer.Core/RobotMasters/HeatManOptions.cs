using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class HeatManOptions : BaseRobotMasterOptions
    {
        public HeatManOptions(byte[] romBytes) : base(romBytes, Addresses.HeatManColor1, Addresses.HeatManColor2)
        {
        }
    }
}
