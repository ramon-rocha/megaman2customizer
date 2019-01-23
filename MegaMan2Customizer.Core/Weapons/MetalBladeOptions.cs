using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class MetalBladeOptions : BaseWeaponOptions
    {
        public MetalBladeOptions(byte[] romBytes) : base(romBytes, Addresses.MetalBladeColor1, Addresses.MetalBladeColor2)
        {
        }
    }
}
