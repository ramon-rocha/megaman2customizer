using System;

namespace MegaMan2Customizer.Core
{
    public class AirShooterOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get => Text.DecodeWeaponName(_romBytes, Addresses.AirShooterName);
            set => throw new NotImplementedException();
        }

        public override char LetterCode
        {
            get => (char)_romBytes[Addresses.AirShooterLetterCode];
            set => _romBytes[Addresses.AirShooterLetterCode] = (byte)value;
        }

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

        public AirShooterOptions(byte[] romBytes) : base(romBytes, Addresses.AirShooterColor1, Addresses.AirShooterColor2, WeaponId.AirShooter)
        {
        }
    }
}
