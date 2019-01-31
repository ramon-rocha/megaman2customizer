using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class RobotMasterOptions
    {
        public BubbleManOptions BubbleMan { get; }

        public AirManOptions AirMan { get; }

        public QuickManOptions QuickMan { get; }

        public HeatManOptions HeatMan { get; }

        public WoodManOptions WoodMan { get; }

        public MetalManOptions MetalMan { get; }

        public FlashManOptions FlashMan { get; }

        public CrashManOptions CrashMan { get; }

        public RobotMasterOptions(byte[] romBytes)
        {
            this.BubbleMan = new BubbleManOptions(romBytes);
            this.AirMan = new AirManOptions(romBytes);
            this.QuickMan = new QuickManOptions(romBytes);
            this.HeatMan = new HeatManOptions(romBytes);
            this.WoodMan = new WoodManOptions(romBytes);
            this.MetalMan = new MetalManOptions(romBytes);
            this.FlashMan = new FlashManOptions(romBytes);
            this.CrashMan = new CrashManOptions(romBytes);
        }
    }
}
