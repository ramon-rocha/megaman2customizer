using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class LeafShieldOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.LeafShieldName);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.LeafShieldLetterCode];
            set => _romBytes[Addresses.LeafShieldLetterCode] = (byte)value;
        }

        public LeafShieldOptions(byte[] romBytes) : base(romBytes, Addresses.LeafShieldColor1, Addresses.LeafShieldColor2, WeaponId.LeafShield)
        {
        }
    }
}
