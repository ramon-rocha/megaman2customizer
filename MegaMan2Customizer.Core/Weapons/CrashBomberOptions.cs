using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class CrashBomberOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.CrashBomberName);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.CrashBomberLetterCode];
            set => _romBytes[Addresses.CrashBomberLetterCode] = (byte)value;
        }
        public CrashBomberOptions(byte[] romBytes) : base(romBytes, Addresses.CrashBombColor1, Addresses.CrashBombColor2, WeaponId.CrashBomb)
        {
        }
    }
}
