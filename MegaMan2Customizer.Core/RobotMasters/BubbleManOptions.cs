namespace MegaMan2Customizer.Core
{

    public class BubbleManOptions : BaseRobotMasterOptions
    {
        public byte RiseSpeed
        {
            get => _romBytes[Addresses.BubbleManRiseSpeed];
            set => _romBytes[Addresses.BubbleManRiseSpeed] = value;
        }

        public byte FallSpeed
        {
            get => _romBytes[Addresses.BubbleManFallSpeed];
            set => _romBytes[Addresses.BubbleManFallSpeed] = value;
        }

        public byte MaxHeight
        {
            get => _romBytes[Addresses.BubbleManMaxHeight];
            set => _romBytes[Addresses.BubbleManMaxHeight] = value;
        }

        public byte ShotDelay
        {
            get => _romBytes[Addresses.BubbleManShotDelay];
            set => _romBytes[Addresses.BubbleManShotDelay] = value;
        }

        public decimal ProjectileSpeed
        {
            get => _romBytes.GetDecimal(Addresses.BubbleManProjectileHorzSpeedWhole, Addresses.BubbleManProjectileHorzSpeedFraction);
            set => _romBytes.SetDecimal(Addresses.BubbleManProjectileHorzSpeedWhole, Addresses.BubbleManProjectileHorzSpeedFraction, value);
        }

        public decimal ProjectileVerticalLaunchSpeed
        {
            get => _romBytes.GetDecimal(Addresses.BubbleManProjectileVertLaunchSpeedWhole, Addresses.BubbleManProjectileVertLaunchSpeedFraction);
            set => _romBytes.SetDecimal(Addresses.BubbleManProjectileVertLaunchSpeedWhole, Addresses.BubbleManProjectileVertLaunchSpeedFraction, value);
        }

        public decimal ProjectileBounceSpeed
        {
            get => _romBytes.GetDecimal(Addresses.BubbleManProjectileVertBounceSpeedWhole, Addresses.BubbleManProjectileVertBounceSpeedFraction);
            set => _romBytes.SetDecimal(Addresses.BubbleManProjectileVertBounceSpeedWhole, Addresses.BubbleManProjectileVertBounceSpeedFraction, value);
        }

        public BubbleManOptions(byte[] romBytes) : base(romBytes, Addresses.BubbleManColor1, Addresses.BubbleManColor2)
        {
        }
    }
}