using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class QuickBoomerangOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get =>
                Text.DecodeWeaponName(_romBytes, Addresses.QuickBoomerangNameLine1) +
                Text.DecodeWeaponName(_romBytes, Addresses.QuickBoomerangNameLine2);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.QuickBoomerangLetterCode];
            set => _romBytes[Addresses.QuickBoomerangLetterCode] = (byte)value;
        }

        public QuickBoomerangOptions(byte[] romBytes) : base(romBytes, Addresses.QuickBoomerangColor1, Addresses.QuickBoomerangColor2, WeaponId.QuickBoomerang)
        {
        }
    }
}
