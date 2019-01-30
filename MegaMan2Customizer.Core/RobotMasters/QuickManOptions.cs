namespace MegaMan2Customizer.Core
{
    public class QuickManOptions : BaseRobotMasterOptions
    {
        public byte ProjectileCount
        {
            get => _romBytes[Addresses.QuickManProjectileCount];
            set => _romBytes[Addresses.QuickManProjectileCount] = value;
        }

        public byte ProjectileReturnDelay
        {
            get => _romBytes[Addresses.QuickManProjectileReturnDelay];
            set => _romBytes[Addresses.QuickManProjectileReturnDelay] = value;
        }

        public byte ProjectileLaunchSpeed
        {
            get => _romBytes[Addresses.QuickManProjectileLaunchSpeed];
            set => _romBytes[Addresses.QuickManProjectileLaunchSpeed] = value;
        }

        public byte ProjectileReturnSpeed
        {
            get => _romBytes[Addresses.QuickManProjectileReturnSpeed];
            set => _romBytes[Addresses.QuickManProjectileReturnSpeed] = value;
        }

        public byte Jump1Height
        {
            get => _romBytes[Addresses.QuickManJump1Height];
            set => _romBytes[Addresses.QuickManJump1Height] = value;
        }

        public byte Jump2Height
        {
            get => _romBytes[Addresses.QuickManJump2Height];
            set => _romBytes[Addresses.QuickManJump2Height] = value;
        }

        public byte Jump3Height
        {
            get => _romBytes[Addresses.QuickManJump3Height];
            set => _romBytes[Addresses.QuickManJump3Height] = value;
        }

        public byte RunSpeed
        {
            get => _romBytes[Addresses.QuickManRunSpeed];
            set => _romBytes[Addresses.QuickManRunSpeed] = value;
        }

        public byte RunDuration
        {
            get => _romBytes[Addresses.QuickManRunDuration];
            set => _romBytes[Addresses.QuickManRunDuration] = value;
        }

        public QuickManOptions(byte[] romBytes) : base(romBytes, Addresses.QuickManColor1, Addresses.QuickManColor2)
        {
        }
    }
}