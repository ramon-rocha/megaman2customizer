using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using MegaMan2Configurator.Core;
using Xunit;

namespace MegaManConfigurator.Core.Tests
{
    public class OfficialRomTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Fact]
        public void MegaManOptions_StartingHealth_IsDefault28()
        {
            var rom = new MegaManRom(_romBytes.ToArray());
            Assert.Equal(28, rom.MegaManOptions.StartingHealth);
        }

        [Fact]
        public void MegaManOptions_MaxHealth_IsDefault28()
        {
            var rom = new MegaManRom(_romBytes.ToArray());
            Assert.Equal(28, rom.MegaManOptions.MaxHealth);
        }

        [Fact]
        public void MenuOptions_DefaultColors()
        {
            var rom = new MegaManRom(_romBytes.ToArray());
            Assert.Equal(new Color(Pigment.Fuchsia, Brightness.Pastel), rom.StartMenuOptions.BorderColor);
            Assert.Equal(new Color(Pigment.Blue, Brightness.Bright), rom.StartMenuOptions.BackgroundColor);
            Assert.Equal(new Color(Pigment.Blue, Brightness.Normal), rom.StartMenuOptions.ShadowColor);
        }
    }
}
