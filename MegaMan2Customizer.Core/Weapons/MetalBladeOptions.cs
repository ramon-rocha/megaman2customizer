using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class MetalBladeOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.MetalBladeName);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.MetalBladeLetterCode];
            set => _romBytes[Addresses.MetalBladeLetterCode] = (byte)value;
        }

        public MetalBladeOptions(byte[] romBytes) : base(romBytes, Addresses.MetalBladeColor1, Addresses.MetalBladeColor2, WeaponId.MetalBlade)
        {
        }
    }
}
