namespace MegaMan2Customizer.Core
{
    public class WoodManOptions : BaseRobotMasterOptions
    {
        public Color LeafColor
        {
            get => new Color(_romBytes[Addresses.WoodManLeafColor]);
            set => _romBytes[Addresses.WoodManLeafColor] = value.Value;
        }

        public byte LeafDelay
        {
            get => _romBytes[Addresses.WoodManLeafDelay];
            set => _romBytes[Addresses.WoodManLeafDelay] = value;
        }

        public byte JumpHeight
        {
            get => _romBytes[Addresses.WoodManJumpHeight];
            set => _romBytes[Addresses.WoodManJumpHeight] = value;
        }

        public byte JumpDistance
        {
            get => _romBytes[Addresses.WoodManJumpDistance];
            set => _romBytes[Addresses.WoodManJumpDistance] = value;
        }

        public byte ProjectileSpeed
        {
            get => _romBytes[Addresses.WoodManProjectileSpeed];
            set => _romBytes[Addresses.WoodManProjectileSpeed] = value;
        }

        public byte FallingLeafCount
        {
            get => _romBytes[Addresses.WoodManFallingLeafCount];
            set => _romBytes[Addresses.WoodManFallingLeafCount] = value;
        }

        public byte FallingLeafHorizontalSpeed
        {
            get => _romBytes[Addresses.WoodManFallingLeafHorzSpeed];
            set => _romBytes[Addresses.WoodManFallingLeafHorzSpeed] = value;
        }

        public byte FallingLeafVerticalSpeed
        {
            get => _romBytes[Addresses.WoodManFallingLeafVertSpeed];
            set => _romBytes[Addresses.WoodManFallingLeafVertSpeed] = value;
        }

        public WoodManOptions(byte[] romBytes) : base(romBytes, Addresses.WoodManColor1, Addresses.WoodManColor2, Addresses.WoodManWeaponOnDefeat, Addresses.WoodManItemOnDefeat)
        {
        }
    }
}