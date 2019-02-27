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

        public TimeStopperOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.TimeStopperColor1,
            secondaryColorAddress: Addresses.TimeStopperColor2,
            weaponNameAddress: Addresses.TimeStopperName,
            cutSceneLetterAddress: Addresses.TimeStopperCutSceneLetterCode,
            menuLetterAddress: Addresses.TimeStopperMenuLetterCode,
            weaponId: WeaponId.TimeStopper)
        {
        }
    }
}
