using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class BubbleManOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void PrimaryColor_IsWhite()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("White", rom.RobotMasters.BubbleMan.PrimaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_IsSeaGreen()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Sea Green", rom.RobotMasters.BubbleMan.SecondaryColor.Name);
        }

        [Fact]
        public void RiseSpeed_Is1()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(1, rom.RobotMasters.BubbleMan.RiseSpeed);
        }

        [Fact]
        public void MaxHeight_Is80()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(80, rom.RobotMasters.BubbleMan.MaxHeight);
        }

        [Fact]
        public void FallSpeed_Is1()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(255, rom.RobotMasters.BubbleMan.FallSpeed);
        }

        [Fact]
        public void ProjectileSpeed_Is1AndChange()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(1.00390625m, rom.RobotMasters.BubbleMan.ProjectileSpeed);
        }

        [Fact]
        public void ProjectileVerticalLaunchSpeed_Is3Point46()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(3.4609375m, rom.RobotMasters.BubbleMan.ProjectileVerticalLaunchSpeed);
        }

        [Fact]
        public void ProjectileBounceSpeed_Is3Point46()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(3.4609375m, rom.RobotMasters.BubbleMan.ProjectileBounceSpeed);
        }

        [Fact]
        public void ShotDelay_Is18()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(18, rom.RobotMasters.BubbleMan.ShotDelay);
        }
    }
}
