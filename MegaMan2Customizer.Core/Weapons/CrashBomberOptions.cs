using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class CrashBomberOptions : BaseWeaponOptions
    {
        public CrashBomberOptions(byte[] romBytes) : base(romBytes, Addresses.CrashBombColor1, Addresses.CrashBombColor2)
        {
        }
    }
}
