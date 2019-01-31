using MegaMan2Customizer.Core;
using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class ColorTests
    {
        [Theory]
        [InlineData(0x00, "Dark Gray")]
        [InlineData(0x10, "Light Gray")]
        [InlineData(0x20, "White")]
        [InlineData(0x30, "White")]
        [InlineData(0x16, "Red")]
        [InlineData(0x1A, "Green")]
        [InlineData(0x11, "Blue")]
        [InlineData(0x06, "Dark Red")]
        [InlineData(0x0A, "Dark Green")]
        [InlineData(0x01, "Dark Blue")]
        [InlineData(0x26, "Light Red")]
        [InlineData(0x2A, "Light Green")]
        [InlineData(0x21, "Light Blue")]
        [InlineData(0x36, "Very Light Red")]
        [InlineData(0x3A, "Very Light Green")]
        [InlineData(0x31, "Very Light Blue")]
        [InlineData(0x0D, "Black")]
        [InlineData(0x1D, "Black")]
        [InlineData(0x2D, "Dark Gray")]
        [InlineData(0x3D, "Gray")]
        [InlineData(0x08, "Brown")]
        [InlineData(0x18, "Dark Yellow")]
        [InlineData(0x28, "Yellow")]
        [InlineData(0x38, "Light Yellow")]
        public void Color_ConstructsFromByte(byte value, string name)
        {
            var color = new Color(value);
            Assert.Equal(name, color.Name);
        }

        [Theory]
        [InlineData(Pigment.Red, Lightness.Normal, "Red")]
        [InlineData(Pigment.Green, Lightness.Normal, "Green")]
        [InlineData(Pigment.Blue, Lightness.Normal, "Blue")]
        [InlineData(Pigment.Red, Lightness.Dark, "Dark Red")]
        [InlineData(Pigment.Green, Lightness.Dark, "Dark Green")]
        [InlineData(Pigment.Blue, Lightness.Dark, "Dark Blue")]
        [InlineData(Pigment.Red, Lightness.Light, "Light Red")]
        [InlineData(Pigment.Green, Lightness.Light, "Light Green")]
        [InlineData(Pigment.Blue, Lightness.Light, "Light Blue")]
        [InlineData(Pigment.Red, Lightness.VeryLight, "Very Light Red")]
        [InlineData(Pigment.Green, Lightness.VeryLight, "Very Light Green")]
        [InlineData(Pigment.Blue, Lightness.VeryLight, "Very Light Blue")]
        [InlineData(Pigment.White, Lightness.Normal, "Light Gray")]
        [InlineData(Pigment.White, Lightness.Dark, "Dark Gray")]
        [InlineData(Pigment.White, Lightness.Light, "White")]
        [InlineData(Pigment.White, Lightness.VeryLight, "White")]
        [InlineData(Pigment.Black, Lightness.Normal, "Black")]
        [InlineData(Pigment.Black, Lightness.Dark, "Black")]
        [InlineData(Pigment.Black, Lightness.Light, "Dark Gray")]
        [InlineData(Pigment.Black, Lightness.VeryLight, "Gray")]
        [InlineData(Pigment.SeaGreen, Lightness.Normal, "Sea Green")]
        [InlineData(Pigment.SeaGreen, Lightness.Dark, "Dark Sea Green")]
        [InlineData(Pigment.SeaGreen, Lightness.Light, "Light Sea Green")]
        [InlineData(Pigment.SeaGreen, Lightness.VeryLight, "Very Light Sea Green")]
        [InlineData(Pigment.ForestGreen, Lightness.Normal, "Forest Green")]
        [InlineData(Pigment.ForestGreen, Lightness.Dark, "Dark Forest Green")]
        [InlineData(Pigment.ForestGreen, Lightness.Light, "Light Forest Green")]
        [InlineData(Pigment.ForestGreen, Lightness.VeryLight, "Very Light Forest Green")]
        [InlineData(Pigment.Yellow, Lightness.Dark, "Brown")]
        [InlineData(Pigment.Yellow, Lightness.Normal, "Dark Yellow")]
        [InlineData(Pigment.Yellow, Lightness.Light, "Yellow")]
        [InlineData(Pigment.Yellow, Lightness.VeryLight, "Light Yellow")]
        public void Name_BasedOnPigmentAndLightness(Pigment pigment, Lightness lightness, string name)
        {
            var color = new Color(pigment, lightness);
            Assert.Equal(name, color.Name);
        }

        [Theory]
        [InlineData(Pigment.Red, Lightness.Normal, 0x16)]
        [InlineData(Pigment.Green, Lightness.Normal, 0x1A)]
        [InlineData(Pigment.Blue, Lightness.Normal, 0x11)]
        [InlineData(Pigment.Red, Lightness.Dark, 0x06)]
        [InlineData(Pigment.Green, Lightness.Dark, 0x0A)]
        [InlineData(Pigment.Blue, Lightness.Dark, 0x01)]
        [InlineData(Pigment.Red, Lightness.Light, 0x26)]
        [InlineData(Pigment.Green, Lightness.Light, 0x2A)]
        [InlineData(Pigment.Blue, Lightness.Light, 0x21)]
        [InlineData(Pigment.Red, Lightness.VeryLight, 0x36)]
        [InlineData(Pigment.Green, Lightness.VeryLight, 0x3A)]
        [InlineData(Pigment.Blue, Lightness.VeryLight, 0x31)]
        [InlineData(Pigment.White, Lightness.Normal, 0x10)]
        [InlineData(Pigment.White, Lightness.Dark, 0x00)]
        [InlineData(Pigment.White, Lightness.Light, 0x20)]
        [InlineData(Pigment.White, Lightness.VeryLight, 0x20)]
        [InlineData(Pigment.Black, Lightness.Normal, 0x1D)]
        [InlineData(Pigment.Black, Lightness.Dark, 0x1D)]
        [InlineData(Pigment.Black, Lightness.Light, 0x2D)]
        [InlineData(Pigment.Black, Lightness.VeryLight, 0x3D)]
        public void Value_BasedOnPigmentAndlightness(Pigment pigment, Lightness lightness, byte value)
        {
            var color = new Color(pigment, lightness);
            Assert.Equal(value, color.Value);
        }
    }
}
