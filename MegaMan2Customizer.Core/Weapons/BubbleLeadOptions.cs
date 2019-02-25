using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class BubbleLeadOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.BubbleLeadName);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.BubbleLeadLetterCode];
            set => _romBytes[Addresses.BubbleLeadLetterCode] = (byte)value;
        }
        public BubbleLeadOptions(byte[] romBytes) : base(romBytes, Addresses.BubbleLeadColor1, Addresses.BubbleLeadColor2, WeaponId.BubbleLead)
        {
        }
    }
}
