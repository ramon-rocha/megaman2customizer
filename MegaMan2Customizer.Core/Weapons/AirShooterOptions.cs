namespace MegaMan2Customizer.Core
{
    public class AirShooterOptions : BaseWeaponOptions
    {
        public byte ProjectileCount
        {
            get => _romBytes[Addresses.AirShooterProjectileCount];
            set => _romBytes[Addresses.AirShooterProjectileCount] = value;
        }

        public byte AmmoUsed
        {
            get => _romBytes[Addresses.AirShooterAmmoUsed];
            set => _romBytes[Addresses.AirShooterAmmoUsed] = value;
        }

        public byte Projectile1HorizontalSpeed
        {
            get => _romBytes[Addresses.AirShooterHorizSpeedWhole1];
            set => _romBytes[Addresses.AirShooterHorizSpeedWhole1] = value;
        }

        public byte Projectile2HorizontalSpeed
        {
            get => _romBytes[Addresses.AirShooterHorizSpeedWhole2];
            set => _romBytes[Addresses.AirShooterHorizSpeedWhole2] = value;
        }

        public byte Projectile3HorizontalSpeed
        {
            get => _romBytes[Addresses.AirShooterHorizSpeedWhole3];
            set => _romBytes[Addresses.AirShooterHorizSpeedWhole3] = value;
        }

        public byte ProjectileVerticalAcceleration
        {
            get => _romBytes[Addresses.AirShooterVertAccelWhole];
            set => _romBytes[Addresses.AirShooterVertAccelWhole] = value;
        }

        public AirShooterOptions(byte[] romBytes) : base(romBytes, Addresses.AirShooterColor1, Addresses.AirShooterColor2)
        {
        }
    }
}
