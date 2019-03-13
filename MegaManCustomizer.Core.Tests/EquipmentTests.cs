using System.Collections.Immutable;
using System.IO;
using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class EquipmentTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void BubbleMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.BubbleLead, rom.RobotMasters.BubbleMan.WeaponOnDefeat);
            Assert.Equal(ItemId.None, rom.RobotMasters.BubbleMan.ItemOnDefeat);
        }

        [Fact]
        public void AirMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.AirShooter, rom.RobotMasters.AirMan.WeaponOnDefeat);
            Assert.Equal(ItemId.Item2, rom.RobotMasters.AirMan.ItemOnDefeat);
        }

        [Fact]
        public void QuickMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.QuickBoomerang, rom.RobotMasters.QuickMan.WeaponOnDefeat);
            Assert.Equal(ItemId.None, rom.RobotMasters.QuickMan.ItemOnDefeat);
        }

        [Fact]
        public void HeatMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.AtomicFire, rom.RobotMasters.HeatMan.WeaponOnDefeat);
            Assert.Equal(ItemId.Item1, rom.RobotMasters.HeatMan.ItemOnDefeat);
        }

        [Fact]
        public void WoodMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.LeafShield, rom.RobotMasters.WoodMan.WeaponOnDefeat);
            Assert.Equal(ItemId.None, rom.RobotMasters.WoodMan.ItemOnDefeat);
        }

        [Fact]
        public void MetalMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.MetalBlade, rom.RobotMasters.MetalMan.WeaponOnDefeat);
            Assert.Equal(ItemId.None, rom.RobotMasters.MetalMan.ItemOnDefeat);
        }

        [Fact]
        public void FlashMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.TimeStopper, rom.RobotMasters.FlashMan.WeaponOnDefeat);
            Assert.Equal(ItemId.Item3, rom.RobotMasters.FlashMan.ItemOnDefeat);
        }

        [Fact]
        public void CrashMan_DefaultEquipment()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(WeaponId.CrashBomber, rom.RobotMasters.CrashMan.WeaponOnDefeat);
            Assert.Equal(ItemId.None, rom.RobotMasters.CrashMan.ItemOnDefeat);
        }
    }
}
