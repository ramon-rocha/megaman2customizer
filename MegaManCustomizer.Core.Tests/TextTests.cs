using System.Collections.Immutable;
using System.IO;
using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class TextTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [InlineData("  GET EQUIPPED", Addresses.GetEquippedText1)]
        [InlineData("  WITH        ", Addresses.GetEquippedText2)]
        [InlineData("  ATOMIC FIRE ", Addresses.AtomicFireName)]
        [InlineData(" MESSAGE FROM ", Addresses.MessageFromDrLightText1)]
        [InlineData(" DR.LIGHT.    ", Addresses.MessageFromDrLightText2)]
        [InlineData("COMPLETED!    ", Addresses.ItemCompletedText1)]
        [InlineData("GET YOUR      ", Addresses.ItemCompletedText2)]
        [InlineData("WEAPONS READY!", Addresses.ItemCompletedText3)]
        [Theory]
        public void DefaultCutSceneText(string expected, int address)
        {
            var rom = new MegaMan2Rom(_romBytes);
            string actual = Text.DecodeCutScene(rom.Bytes, address);
            Assert.Equal(expected, actual);
        }
    }
}
