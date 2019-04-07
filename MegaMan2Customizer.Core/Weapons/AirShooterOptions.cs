namespace MegaMan2Customizer.Core
{
    public class AirShooterOptions : BaseWeaponOptions
    {
        public byte ProjectileCount
        {
            get => (byte)(_romBytes[Addresses.AirShooterProjectileCount] - 1);
            set => _romBytes[Addresses.AirShooterProjectileCount] = (byte)(value + 1);
        }

        public byte AmmoUsed
        {
            get => _romBytes[Addresses.AirShooterAmmoUsed];
            set => _romBytes[Addresses.AirShooterAmmoUsed] = value;
        }

        public decimal Projectile1HorizontalSpeed
        {
            get => _romBytes.GetDecimal(Addresses.AirShooterHorizSpeedWhole1, Addresses.AirShooterHorizSpeedFraction1);
            set => _romBytes.SetDecimal(Addresses.AirShooterHorizSpeedWhole1, Addresses.AirShooterHorizSpeedFraction1, value);
        }

        public decimal Projectile2HorizontalSpeed
        {
            get => _romBytes.GetDecimal(Addresses.AirShooterHorizSpeedWhole2, Addresses.AirShooterHorizSpeedFraction2);
            set => _romBytes.SetDecimal(Addresses.AirShooterHorizSpeedWhole2, Addresses.AirShooterHorizSpeedFraction2, value);
        }

        public decimal Projectile3HorizontalSpeed
        {
            get => _romBytes.GetDecimal(Addresses.AirShooterHorizSpeedWhole3, Addresses.AirShooterHorizSpeedFraction3);
            set => _romBytes.SetDecimal(Addresses.AirShooterHorizSpeedWhole3, Addresses.AirShooterHorizSpeedFraction3, value);
        }

        public decimal ProjectileVerticalAcceleration
        {
            get => _romBytes.GetDecimal(Addresses.AirShooterVertAccelWhole, Addresses.AirShooterVertAccelFraction);
            set => _romBytes.SetDecimal(Addresses.AirShooterVertAccelWhole, Addresses.AirShooterVertAccelFraction, value);
        }

        public AirShooterOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.AirShooterColor1,
            secondaryColorAddress: Addresses.AirShooterColor2,
            weaponNameAddress: Addresses.AirShooterName,
            cutSceneLetterAddress: Addresses.AirShooterCutSceneLetterCode,
            menuLetterAddress: Addresses.AirShooterMenuLetterCode,
            weaponId: WeaponId.AirShooter)
        {
        }
    }
}
