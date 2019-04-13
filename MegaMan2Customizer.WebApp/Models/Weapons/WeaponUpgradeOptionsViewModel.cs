using System.ComponentModel.DataAnnotations;

namespace MegaMan2Customizer.WebApp.Models
{
    /// <summary>
    /// Contains options for all weapon upgrades
    /// </summary>
    public class WeaponUpgradeOptionsViewModel
    {
        public AtomicFireOptionsViewModel AtomicFire { get; set; } = new AtomicFireOptionsViewModel();

        public AirShooterOptionsViewModel AirShooter { get; set; } = new AirShooterOptionsViewModel();

        public LeafShieldOptionsViewModel LeafShield { get; set; } = new LeafShieldOptionsViewModel();

        public BubbleLeadOptionsViewModel BubbleLead { get; set; } = new BubbleLeadOptionsViewModel();

        public QuickBoomerangOptionsViewModel QuickBoomerang { get; set; } = new QuickBoomerangOptionsViewModel();

        public TimeStopperOptionsViewModel TimeStopper { get; set; } = new TimeStopperOptionsViewModel();

        public MetalBladeOptionsViewModel MetalBlade { get; set; } = new MetalBladeOptionsViewModel();

        public CrashBomberOptionsViewModel CrashBomber { get; set; } = new CrashBomberOptionsViewModel();

    }
}
