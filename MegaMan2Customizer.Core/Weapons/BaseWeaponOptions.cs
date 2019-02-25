﻿namespace MegaMan2Customizer.Core
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

        public abstract string Name { get; set; }

        public abstract char LetterCode { get; set; }

        public WeaponId WeaponId { get; }

        public BaseWeaponOptions(byte[] romBytes, int primaryColorAddress, int secondaryColorAddress, WeaponId weaponId)
        {
            _romBytes = romBytes;
            _primaryColorAddress = primaryColorAddress;
            _secondaryColorAddress = secondaryColorAddress;
            this.WeaponId = weaponId;
        }
    }
}
