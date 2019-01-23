using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class QuickBoomerangOptions : BaseWeaponOptions
    {
        public QuickBoomerangOptions(byte[] romBytes) : base(romBytes, Addresses.QuickBoomerangColor1, Addresses.QuickBoomerangColor2)
        {
        }
    }
}
