namespace MegaMan2Configurator.Core
{
    public class MegaManOptions
    {
        private readonly byte[] _romBytes;

        public byte StartingHealth
        {
            get => _romBytes[Addresses.MegaManStartingHealth];
            set => _romBytes[Addresses.MegaManStartingHealth] = value;
        }

        public byte MaxHealth
        {
            get => _romBytes[Addresses.MegaManMaxHealth];
            set => _romBytes[Addresses.MegaManMaxHealth] = value;
        }

        public byte MaxBusterShots
        {
            get => _romBytes[Addresses.MegaManBusterMaxShots];
            set => _romBytes[Addresses.MegaManBusterMaxShots] = value;
        }

        public byte BusterSpeed
        {
            get => _romBytes[Addresses.MegaManBusterSpeed];
            set => _romBytes[Addresses.MegaManBusterSpeed] = value;
        }

        public byte Speed
        {
            get => _romBytes[Addresses.MegaManWalkSpeed];
            set => _romBytes[Addresses.MegaManWalkSpeed] = _romBytes[Addresses.MegaManJumpHorizontalSpeed] = value;
        }

        public byte JumpHeight
        {
            get => _romBytes[Addresses.MegaManJumpHeight];
            set => _romBytes[Addresses.MegaManJumpHeight] = value;
        }

        public MegaManOptions(byte[] romBytes) => _romBytes = romBytes;
    }
}
