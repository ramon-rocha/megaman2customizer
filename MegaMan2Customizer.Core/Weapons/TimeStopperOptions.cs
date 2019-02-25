using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class TimeStopperOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.TimeStopperName);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.TimeStopperLetterCode];
            set => _romBytes[Addresses.TimeStopperLetterCode] = (byte)value;
        }

        public byte DrainRateDelay
        {
            get => _romBytes[Addresses.TimeStopperDrainRateDelay];
            set => _romBytes[Addresses.TimeStopperDrainRateDelay] = value;
        }

        public byte DelayBeforeDrain
        {
            get => _romBytes[Addresses.TimeStopperDelayBeforeDrain];
            set => _romBytes[Addresses.TimeStopperDelayBeforeDrain] = value;
        }

        public TimeStopperOptions(byte[] romBytes) : base(romBytes, Addresses.TimeStopperColor1, Addresses.TimeStopperColor2, WeaponId.TimeStopper)
        {
        }
    }
}
