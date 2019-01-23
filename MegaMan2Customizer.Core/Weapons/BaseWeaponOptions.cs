namespace MegaMan2Customizer.Core
{
    public abstract class BaseWeaponOptions
    {
        protected readonly byte[] _romBytes;

        private readonly int _primaryColorAddress;

        private readonly int _secondaryColorAddress;

        public virtual Color PrimaryColor
        {
            get => new Color(_romBytes[_primaryColorAddress]);
            set => _romBytes[_primaryColorAddress] = value.Value;
        }

        public virtual Color SecondaryColor
        {
            get => new Color(_romBytes[_secondaryColorAddress]);
            set => _romBytes[_secondaryColorAddress] = value.Value;
        }

        public BaseWeaponOptions(byte[] romBytes, int primaryColorAddress, int secondaryColorAddress)
        {
            _romBytes = romBytes;
            _primaryColorAddress = primaryColorAddress;
            _secondaryColorAddress = secondaryColorAddress;
        }
    }
}
