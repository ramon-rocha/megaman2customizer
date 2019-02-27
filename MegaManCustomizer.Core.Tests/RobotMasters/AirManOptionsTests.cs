using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class AirManOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void PrimaryColor_IsBlue()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Blue", rom.RobotMasters.AirMan.PrimaryColor.Name);
        }

        [Fact]
        public void SecondaryColor_IsYellow()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal("Yellow", rom.RobotMasters.AirMan.SecondaryColor.Name);
        }
        
        [Fact]
        public void TornadoPatterns_Has5Patterns_With6TornadoesPerPattern()
        {
            var rom = new MegaManRom(_romBytes);
            var airMan = rom.RobotMasters.AirMan;
            Assert.Equal(5, airMan.Patterns.Count);
            foreach (TornadoPattern pattern in airMan.Patterns)
            {
                Assert.Equal(6, pattern.Tornados.Count);
            }
        }

        [Theory]
        [InlineData(0, 0, "4.00000000", "0.00000000", 12)]
        [InlineData(0, 1, "3.93750000", "0.69140625", 22)]
        [InlineData(0, 2, "3.31250000", "2.23437500", 36)]
        [InlineData(0, 3, "2.23437500", "3.31250000", 14)]
        [InlineData(0, 4, "2.00000000", "3.46093750", 36)]
        [InlineData(0, 5, "0.00000000", "4.00000000", 24)]
        [InlineData(1, 0, "3.82421875", "1.16796875", 27)]
        [InlineData(1, 1, "3.80078125", "1.23437500", 14)]
        [InlineData(1, 2, "2.40625000", "3.19140625", 30)]
        [InlineData(1, 3, "2.05859375", "3.41796875", 42)]
        [InlineData(1, 4, "1.10156250", "3.85546875", 29)]
        [InlineData(1, 5, "0.00000000", "4.00000000", 12)]
        [InlineData(2, 0, "3.65234375", "1.62500000", 13)]
        [InlineData(2, 1, "2.40625000", "3.19140625", 10)]
        [InlineData(2, 2, "2.00000000", "3.46093750", 32)]
        [InlineData(2, 3, "1.49609375", "3.70703125", 21)]
        [InlineData(2, 4, "0.69140625", "3.93750000", 34)]
        [InlineData(2, 5, "255.65234375", "3.984375", 24)] // what does this mean?
        [InlineData(3, 0, "3.53125000", "1.87500000", 33)]
        [InlineData(3, 1, "3.31250000", "2.23437500", 21)]
        [InlineData(3, 2, "2.82812500", "2.82812500", 5)]
        [InlineData(3, 3, "1.81250000", "3.56250000", 13)]
        [InlineData(3, 4, "1.81250000", "3.56250000", 35)]
        [InlineData(3, 5, "255.72265625", "3.98828125", 28)] // is 255 moving down?
        [InlineData(4, 0, "3.59375000", "1.75000000", 26)]
        [InlineData(4, 1, "3.31250000", "2.23437500", 14)]
        [InlineData(4, 2, "2.23437500", "3.31250000", 28)]
        [InlineData(4, 3, "1.10156250", "3.85546875", 29)]
        [InlineData(4, 4, "0.48437500", "3.96875000", 16)]
        [InlineData(4, 5, "0.20703125", "3.99218750", 36)]
        public void TornadoPatterns_DefaultValues(int patternIndex, int tornadoIndex, string vertVelocityText, string horzVelocityText, byte flightTime)
        {
            var rom = new MegaManRom(_romBytes);
            var airMan = rom.RobotMasters.AirMan;

            var v = decimal.Parse(vertVelocityText);
            var h = decimal.Parse(horzVelocityText);

            Assert.Equal(v, airMan.Patterns[patternIndex].Tornados[tornadoIndex].VerticalVelocity);
            Assert.Equal(h, airMan.Patterns[patternIndex].Tornados[tornadoIndex].HorizontalVelocity);
            Assert.Equal(flightTime, airMan.Patterns[patternIndex].Tornados[tornadoIndex].FlightTime);
        }

        [Fact]
        public void NumberOfPatterns_BeforeShooting_Is3()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(3, rom.RobotMasters.AirMan.ShotsBeforeJumping);
        }

        [Fact]
        public void AirManJump1Distance_Is1Point22()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(1.22265625m, rom.RobotMasters.AirMan.Jump1Distance);
        }

        [Fact]
        public void AirManJump1Height_Is4Point89()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(4.8984375m, rom.RobotMasters.AirMan.Jump1Height);
        }

        [Fact]
        public void AirManJump2Distance_Is1Point60()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(1.6015625m, rom.RobotMasters.AirMan.Jump2Distance);
        }

        [Fact]
        public void AirManJump2Height_Is7Point46()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(7.4609375m, rom.RobotMasters.AirMan.Jump2Height);
        }
    }
}
