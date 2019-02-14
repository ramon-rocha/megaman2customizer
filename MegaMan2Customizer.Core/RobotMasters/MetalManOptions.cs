namespace MegaMan2Customizer.Core
{
    public class MetalManOptions : BaseRobotMasterOptions
    {
        public Color BladeColor
        {
            get => new Color(_romBytes[Addresses.MetalManBladeColor]);
            set => _romBytes[Addresses.MetalManBladeColor] = value.Value;
        }
        
        public byte ProjectileSpeed
        {
            get => _romBytes[Addresses.MetalManProjectileSpeed];
            set => _romBytes[Addresses.MetalManProjectileSpeed] = value;
        }

        public byte Jump1Height
        {
            get => _romBytes[Addresses.MetalManJump1Height];
            set => _romBytes[Addresses.MetalManJump1Height] = value;
        }

        public byte Jump2Height
        {
            get => _romBytes[Addresses.MetalManJump2Height];
            set => _romBytes[Addresses.MetalManJump2Height] = value;
        }

        public byte Jump3Height
        {
            get => _romBytes[Addresses.MetalManJump3Height];
            set => _romBytes[Addresses.MetalManJump3Height] = value;
        }

        public MetalManOptions(byte[] romBytes) : base(romBytes, Addresses.MetalManColor1, Addresses.MetalManColor2)
        {
        }
    }
}