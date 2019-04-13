namespace MegaMan2Customizer.WebApp.Models
{
    /// <summary>
    /// Contains options for all weapon upgrades
    /// </summary>
    public class WeaponUpgradeOptionsViewModel
    {
        public AtomicFireOptionsViewModel AtomicFire { get; set; }

        public AirShooterOptionsViewModel AirShooter { get; set; }

        public LeafShieldOptionsViewModel LeafShield { get; set; }

        public BubbleLeadOptionsViewModel BubbleLead { get; set; }

        public QuickBoomerangOptionsViewModel QuickBoomerang { get; set; }

        public TimeStopperOptionsViewModel TimeStopper { get; set; }

        public MetalBladeOptionsViewModel MetalBlade { get; set; }

        public CrashBomberOptionsViewModel CrashBomber { get; set; }

    }
}
