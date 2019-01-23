using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class BubbleLeadOptions : BaseWeaponOptions
    {
        public BubbleLeadOptions(byte[] romBytes) : base(romBytes, Addresses.BubbleLeadColor1, Addresses.BubbleLeadColor2)
        {
        }
    }
}
