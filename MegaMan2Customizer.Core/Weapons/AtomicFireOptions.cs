namespace MegaMan2Customizer.Core
{
    public class AtomicFireOptions : BaseWeaponOptions
    {
        public override Color SecondaryColor
        {
            set
            {
                _romBytes[Addresses.AtomicFireColor2] = value.Value;
                _romBytes[Addresses.AtomicFireChargeColor1] = value.Value;
                _romBytes[Addresses.AtomicFireChargeColor2] = value.Value;
            }
        }

        public byte Level1AmmoUsed
        {
            get => _romBytes[Addresses.AtomicFireLevel1AmmoUsed];
            set => _romBytes[Addresses.AtomicFireLevel1AmmoUsed] = value;
        }

        public byte Level2ChargeTime
        {
            get => _romBytes[Addresses.AtomicFireLevel2ChargeTime];
            set => _romBytes[Addresses.AtomicFireLevel2ChargeTime] = value;
        }

        public byte Level2AmmoUsed
        {
            get => _romBytes[Addresses.AtomicFireLevel2AmmoUsed];
            set => _romBytes[Addresses.AtomicFireLevel2AmmoUsed] = value;
        }

        public byte Level3ChargeTime
        {
            get => _romBytes[Addresses.AtomicFireLevel3ChargeTime];
            set => _romBytes[Addresses.AtomicFireLevel3ChargeTime] = value;
        }

        public byte Level3AmmoUsed
        {
            get => _romBytes[Addresses.AtomicFireLevel3AmmoUsed];
            set => _romBytes[Addresses.AtomicFireLevel3AmmoUsed] = value;
        }

        public byte ProjectileSpeed
        {
            get => _romBytes[Addresses.AtomicFireProjectileSpeed];
            set => _romBytes[Addresses.AtomicFireProjectileSpeed] = value;
        }

        public AtomicFireOptions(byte[] romBytes) : base(romBytes, Addresses.AtomicFireColor1, Addresses.AtomicFireColor2) { }
    }
}
