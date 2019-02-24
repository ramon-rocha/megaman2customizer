namespace MegaMan2Customizer.Core
{
    public class AllWeaponOptions
    {
        public AirShooterOptions AirShooter { get; }

        public AtomicFireOptions AtomicFire { get; }

        public BubbleLeadOptions BubbleLead { get; }

        public CrashBomberOptions CrashBomber { get; }

        public LeafShieldOptions LeafShield { get; }

        public MetalBladeOptions MetalBlade { get; }

        public QuickBoomerangOptions QuickBoomerang { get; }

        public TimeStopperOptions TimeStopper { get; }

        public AllWeaponOptions(byte[] romBytes)
        {
            this.AirShooter = new AirShooterOptions(romBytes);
            this.AtomicFire = new AtomicFireOptions(romBytes);
            this.BubbleLead = new BubbleLeadOptions(romBytes);
            this.CrashBomber = new CrashBomberOptions(romBytes);
            this.LeafShield = new LeafShieldOptions(romBytes);
            this.MetalBlade = new MetalBladeOptions(romBytes);
            this.QuickBoomerang = new QuickBoomerangOptions(romBytes);
            this.TimeStopper = new TimeStopperOptions(romBytes);
        }
    }
}
