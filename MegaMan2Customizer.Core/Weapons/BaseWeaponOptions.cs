using System;

namespace MegaMan2Customizer.Core
{
    public enum WeaponId
    {
        AtomicFire = 0x01,
        AirShooter = 0x02,
        LeafShield = 0x04,
        BubbleLead = 0x08,
        QuickBoomerang = 0x10,
        TimeStopper = 0x20,
        MetalBlade = 0x40,
        CrashBomb = 0x80
    }

    public abstract class BaseWeaponOptions : IWeaponOptions
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

        private readonly int _weaponNameAddress;

        public virtual string Name
        {
            get => Text.DecodeWeaponName(_romBytes, _weaponNameAddress);
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Weapon name cannot be null or empty");
                }
                if (value.Length > Defaults.MaxCutSceneTextLength)
                {
                    throw new ArgumentException($"Weapon name cannot be longer than {Defaults.MaxCutSceneTextLength} characters");
                }
                byte[] bytes = Text.EncodeCutScene(value);
                bytes.CopyTo(_romBytes, _weaponNameAddress);
            }
        }


        private readonly int _cutSceneLetterAddress;
        private readonly int _menuLetterAddress;

        public virtual char LetterCode
        {
            get => (char)_romBytes[_cutSceneLetterAddress];
            set
            {
                _romBytes[_cutSceneLetterAddress] = Text.EncodeCutScene(value);
                _romBytes[_menuLetterAddress] = Text.EncodeWeaponMenu(value);
            }
        }

        public WeaponId WeaponId { get; }

        public BaseWeaponOptions(byte[] romBytes, int primaryColorAddress, int secondaryColorAddress, int weaponNameAddress, int cutSceneLetterAddress, int menuLetterAddress, WeaponId weaponId)
        {
            _romBytes = romBytes;
            _primaryColorAddress = primaryColorAddress;
            _secondaryColorAddress = secondaryColorAddress;
            _weaponNameAddress = weaponNameAddress;
            _cutSceneLetterAddress = cutSceneLetterAddress;
            _menuLetterAddress = menuLetterAddress;
            this.WeaponId = weaponId;
        }
    }
}
