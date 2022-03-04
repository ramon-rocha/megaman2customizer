namespace MegaMan2Customizer.WebApp.Models;

/// <summary>
/// Contains options for all weapon upgrades
/// </summary>
public class WeaponUpgradeOptionsViewModel
{
    public AtomicFireOptionsViewModel AtomicFire { get; set; } = new();

    public AirShooterOptionsViewModel AirShooter { get; set; } = new();

    public LeafShieldOptionsViewModel LeafShield { get; set; } = new();

    public BubbleLeadOptionsViewModel BubbleLead { get; set; } = new();

    public QuickBoomerangOptionsViewModel QuickBoomerang { get; set; } = new();

    public TimeStopperOptionsViewModel TimeStopper { get; set; } = new();

    public MetalBladeOptionsViewModel MetalBlade { get; set; } = new();

    public CrashBomberOptionsViewModel CrashBomber { get; set; } = new();

}
