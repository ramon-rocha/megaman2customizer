using MegaMan2Customizer.Core;

using System.Collections.Immutable;
using System.IO;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class OfficialRomTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void MegaManOptions_StartingHealth_IsDefault28()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(28, rom.MegaManOptions.StartingHealth);
        }

        [Fact]
        public void MegaManOptions_MaxHealth_IsDefault28()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(28, rom.MegaManOptions.MaxHealth);
        }

        [Fact]
        public void MenuOptions_DefaultColors()
        {
            var rom = new MegaManRom(_romBytes);
            Assert.Equal(new Color(Pigment.Crimson, Lightness.VeryLight), rom.StartMenuOptions.BorderColor);
            Assert.Equal(new Color(Pigment.Blue, Lightness.Light), rom.StartMenuOptions.BackgroundColor);
            Assert.Equal(new Color(Pigment.Blue, Lightness.Normal), rom.StartMenuOptions.ShadowColor);
        }
    }
}
