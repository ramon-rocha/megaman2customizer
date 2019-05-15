using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class AllStageOptions
    {
        public BubbleManStageOptions BubbleMan { get; }

        public AirManStageOptions AirMan { get; }

        public QuickManStageOptions QuickMan { get; }

        public HeatManStageOptions HeatMan { get; }

        public WoodManStageOptions WoodMan { get; }

        public MetalManStageOptions MetalMan { get; }

        public FlashManStageOptions FlashMan { get; }

        public CrashManStageOptions CrashMan { get; }

        public AllStageOptions(byte[] romBytes)
        {
            this.BubbleMan = new BubbleManStageOptions(romBytes);
            this.AirMan = new AirManStageOptions(romBytes);
            this.QuickMan = new QuickManStageOptions(romBytes);
            this.HeatMan = new HeatManStageOptions(romBytes);
            this.WoodMan = new WoodManStageOptions(romBytes);
            this.MetalMan = new MetalManStageOptions(romBytes);
            this.FlashMan = new FlashManStageOptions(romBytes);
            this.CrashMan = new CrashManStageOptions(romBytes);
        }
    }
}
