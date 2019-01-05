using MegaMan2Configurator.Core;
using Xunit;

namespace MegaManConfigurator.Core.Tests
{
    public class ColorTests
    {
        [Theory]
        [InlineData(0x00, "Gray")]
        [InlineData(0x10, "White")]
        [InlineData(0x20, "Bright White")]
        [InlineData(0x30, "Bright White")]
        [InlineData(0x16, "Red")]
        [InlineData(0x1A, "Green")]
        [InlineData(0x11, "Blue")]
        [InlineData(0x06, "Dark Red")]
        [InlineData(0x0A, "Dark Green")]
        [InlineData(0x01, "Dark Blue")]
        [InlineData(0x26, "Bright Red")]
        [InlineData(0x2A, "Bright Green")]
        [InlineData(0x21, "Bright Blue")]
        [InlineData(0x36, "Pastel Red")]
        [InlineData(0x3A, "Pastel Green")]
        [InlineData(0x31, "Pastel Blue")]
        public void Color_ConstructsFromByte(byte value, string name)
        {
            var color = new Color(value);
            Assert.Equal(name, color.Name);
        }

        [Theory]
        [InlineData(Pigment.Red, Brightness.Normal, "Red")]
        [InlineData(Pigment.Green, Brightness.Normal, "Green")]
        [InlineData(Pigment.Blue, Brightness.Normal, "Blue")]
        [InlineData(Pigment.Red, Brightness.Dark, "Dark Red")]
        [InlineData(Pigment.Green, Brightness.Dark, "Dark Green")]
        [InlineData(Pigment.Blue, Brightness.Dark, "Dark Blue")]
        [InlineData(Pigment.Red, Brightness.Bright, "Bright Red")]
        [InlineData(Pigment.Green, Brightness.Bright, "Bright Green")]
        [InlineData(Pigment.Blue, Brightness.Bright, "Bright Blue")]
        [InlineData(Pigment.Red, Brightness.Pastel, "Pastel Red")]
        [InlineData(Pigment.Green, Brightness.Pastel, "Pastel Green")]
        [InlineData(Pigment.Blue, Brightness.Pastel, "Pastel Blue")]
        [InlineData(Pigment.White, Brightness.Normal, "White")]
        [InlineData(Pigment.White, Brightness.Dark, "Gray")]
        [InlineData(Pigment.White, Brightness.Bright, "Bright White")]
        [InlineData(Pigment.White, Brightness.Pastel, "Bright White")]
        [InlineData(Pigment.Black, Brightness.Normal, "Black")]
        [InlineData(Pigment.Black, Brightness.Dark, "Black")]
        [InlineData(Pigment.Black, Brightness.Bright, "Dark Gray")]
        [InlineData(Pigment.Black, Brightness.Pastel, "Light Gray")]
        [InlineData(Pigment.DarkGreen, Brightness.Normal, "Dark Green")]
        [InlineData(Pigment.DarkGreen, Brightness.Dark, "Extra Dark Green")]
        [InlineData(Pigment.DarkGreen, Brightness.Bright, "Lime Green")]
        [InlineData(Pigment.DarkGreen, Brightness.Pastel, "Pastel Lime Green")]
        [InlineData(Pigment.ForestGreen, Brightness.Normal, "Forest Green")]
        [InlineData(Pigment.ForestGreen, Brightness.Dark, "Dark Forest Green")]
        [InlineData(Pigment.ForestGreen, Brightness.Bright, "Bright Forest Green")]
        [InlineData(Pigment.ForestGreen, Brightness.Pastel, "Pastel Forest Green")]
        public void Name_BasedOnPigmentAndBrightness(Pigment pigment, Brightness brightness, string name)
        {
            var color = new Color(pigment, brightness);
            Assert.Equal(name, color.Name);
        }

        [Theory]
        [InlineData(Pigment.Red, Brightness.Normal, 0x16)]
        [InlineData(Pigment.Green, Brightness.Normal, 0x1A)]
        [InlineData(Pigment.Blue, Brightness.Normal, 0x11)]
        [InlineData(Pigment.Red, Brightness.Dark, 0x06)]
        [InlineData(Pigment.Green, Brightness.Dark, 0x0A)]
        [InlineData(Pigment.Blue, Brightness.Dark, 0x01)]
        [InlineData(Pigment.Red, Brightness.Bright, 0x26)]
        [InlineData(Pigment.Green, Brightness.Bright, 0x2A)]
        [InlineData(Pigment.Blue, Brightness.Bright, 0x21)]
        [InlineData(Pigment.Red, Brightness.Pastel, 0x36)]
        [InlineData(Pigment.Green, Brightness.Pastel, 0x3A)]
        [InlineData(Pigment.Blue, Brightness.Pastel, 0x31)]
        [InlineData(Pigment.White, Brightness.Normal, 0x10)]
        [InlineData(Pigment.White, Brightness.Dark, 0x00)]
        [InlineData(Pigment.White, Brightness.Bright, 0x20)]
        [InlineData(Pigment.White, Brightness.Pastel, 0x20)]
        [InlineData(Pigment.Black, Brightness.Normal, 0x1D)]
        [InlineData(Pigment.Black, Brightness.Dark, 0x1D)]
        [InlineData(Pigment.Black, Brightness.Bright, 0x2D)]
        [InlineData(Pigment.Black, Brightness.Pastel, 0x3D)]
        public void Value_BasedOnPigmentAndBrightness(Pigment pigment, Brightness brightness, byte value)
        {
            var color = new Color(pigment, brightness);
            Assert.Equal(value, color.Value);
        }
    }
}
