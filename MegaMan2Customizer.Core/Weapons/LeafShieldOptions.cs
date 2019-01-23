using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class LeafShieldOptions : BaseWeaponOptions
    {
        public LeafShieldOptions(byte[] romBytes) : base(romBytes, Addresses.LeafShieldColor1, Addresses.LeafShieldColor2)
        {
        }
    }
}
