using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class TimeStopperOptions : BaseWeaponOptions
    {
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

        public TimeStopperOptions(byte[] romBytes) : base(romBytes, Addresses.TimeStopperColor1, Addresses.TimeStopperColor2)
        {
        }
    }
}
