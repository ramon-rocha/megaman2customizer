namespace MegaMan2Customizer.WebApp.Models
{
    public class AllRobotMasterOptionsViewModel
    {
        public BubbleManOptionsViewModel BubbleMan { get; set; } = new();

        public AirManOptionsViewModel AirMan { get; set; } = new();

        public QuickManOptionsViewModel QuickMan { get; set; } = new();

        public HeatManOptionsViewModel HeatMan { get; set; } = new();

        public WoodManOptionsViewModel WoodMan { get; set; } = new();

        public MetalManOptionsViewModel MetalMan { get; set; } = new();

        public FlashManOptionsViewModel FlashMan { get; set; } = new();

        public CrashManOptionsViewModel CrashMan { get; set; } = new();
    }
}
