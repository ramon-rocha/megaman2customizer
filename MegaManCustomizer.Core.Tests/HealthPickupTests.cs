using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class HealthPickupTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void LargeHealthPickup_Is5()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(10, rom.LargeHealthPickupAmount);
        }

        [Fact]
        public void SmallHealthPickup_Is3()
        {
            var rom = new MegaMan2Rom(_romBytes);
            Assert.Equal(2, rom.SmallHealthPickupAmount);
        }
    }
}
