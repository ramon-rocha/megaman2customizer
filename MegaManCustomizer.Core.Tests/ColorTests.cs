using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class ColorTests
    {
        [Theory]
        [InlineData(0x00, "Darker Gray")]
        [InlineData(0x10, "Gray")]
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
        [InlineData(0x3D, "Light Gray")]
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
        [InlineData(Chrominance.Red, Luma.Medium, "Red")]
        [InlineData(Chrominance.Green, Luma.Medium, "Green")]
        [InlineData(Chrominance.Blue, Luma.Medium, "Blue")]
        [InlineData(Chrominance.Red, Luma.Dark, "Dark Red")]
        [InlineData(Chrominance.Green, Luma.Dark, "Dark Green")]
        [InlineData(Chrominance.Blue, Luma.Dark, "Dark Blue")]
        [InlineData(Chrominance.Red, Luma.Light, "Light Red")]
        [InlineData(Chrominance.Green, Luma.Light, "Light Green")]
        [InlineData(Chrominance.Blue, Luma.Light, "Light Blue")]
        [InlineData(Chrominance.Red, Luma.VeryLight, "Very Light Red")]
        [InlineData(Chrominance.Green, Luma.VeryLight, "Very Light Green")]
        [InlineData(Chrominance.Blue, Luma.VeryLight, "Very Light Blue")]
        [InlineData(Chrominance.Gray, Luma.Medium, "Gray")]
        [InlineData(Chrominance.Gray, Luma.Dark, "Darker Gray")]
        [InlineData(Chrominance.Gray, Luma.Light, "White")]
        [InlineData(Chrominance.Gray, Luma.VeryLight, "White")]
        [InlineData(Chrominance.Black, Luma.Medium, "Black")]
        [InlineData(Chrominance.Black, Luma.Dark, "Black")]
        [InlineData(Chrominance.Black, Luma.Light, "Dark Gray")]
        [InlineData(Chrominance.Black, Luma.VeryLight, "Light Gray")]
        [InlineData(Chrominance.SeaGreen, Luma.Medium, "Sea Green")]
        [InlineData(Chrominance.SeaGreen, Luma.Dark, "Dark Sea Green")]
        [InlineData(Chrominance.SeaGreen, Luma.Light, "Light Sea Green")]
        [InlineData(Chrominance.SeaGreen, Luma.VeryLight, "Very Light Sea Green")]
        [InlineData(Chrominance.ForestGreen, Luma.Medium, "Forest Green")]
        [InlineData(Chrominance.ForestGreen, Luma.Dark, "Dark Forest Green")]
        [InlineData(Chrominance.ForestGreen, Luma.Light, "Light Forest Green")]
        [InlineData(Chrominance.ForestGreen, Luma.VeryLight, "Very Light Forest Green")]
        [InlineData(Chrominance.Yellow, Luma.Dark, "Brown")]
        [InlineData(Chrominance.Yellow, Luma.Medium, "Dark Yellow")]
        [InlineData(Chrominance.Yellow, Luma.Light, "Yellow")]
        [InlineData(Chrominance.Yellow, Luma.VeryLight, "Light Yellow")]
        [InlineData(Chrominance.Black2, Luma.Dark, "Black")]
        [InlineData(Chrominance.Black2, Luma.Medium, "Black")]
        [InlineData(Chrominance.Black2, Luma.Light, "Black")]
        [InlineData(Chrominance.Black2, Luma.VeryLight, "Black")]
        [InlineData(Chrominance.Black3, Luma.Dark, "Black")]
        [InlineData(Chrominance.Black3, Luma.Medium, "Black")]
        [InlineData(Chrominance.Black3, Luma.Light, "Black")]
        [InlineData(Chrominance.Black3, Luma.VeryLight, "Black")]
        public void Name_BasedOnChromaAndLuma(Chrominance chroma, Luma luma, string name)
        {
            var color = new Color(chroma, luma);
            Assert.Equal(name, color.Name);
        }

        [Theory]
        [InlineData(Chrominance.Red, Luma.Medium, 0x16)]
        [InlineData(Chrominance.Green, Luma.Medium, 0x1A)]
        [InlineData(Chrominance.Blue, Luma.Medium, 0x11)]
        [InlineData(Chrominance.Red, Luma.Dark, 0x06)]
        [InlineData(Chrominance.Green, Luma.Dark, 0x0A)]
        [InlineData(Chrominance.Blue, Luma.Dark, 0x01)]
        [InlineData(Chrominance.Red, Luma.Light, 0x26)]
        [InlineData(Chrominance.Green, Luma.Light, 0x2A)]
        [InlineData(Chrominance.Blue, Luma.Light, 0x21)]
        [InlineData(Chrominance.Red, Luma.VeryLight, 0x36)]
        [InlineData(Chrominance.Green, Luma.VeryLight, 0x3A)]
        [InlineData(Chrominance.Blue, Luma.VeryLight, 0x31)]
        [InlineData(Chrominance.Gray, Luma.Medium, 0x10)]
        [InlineData(Chrominance.Gray, Luma.Dark, 0x00)]
        [InlineData(Chrominance.Gray, Luma.Light, 0x20)]
        [InlineData(Chrominance.Gray, Luma.VeryLight, 0x30)]
        [InlineData(Chrominance.Black, Luma.Dark, 0x0D)]
        [InlineData(Chrominance.Black, Luma.Medium, 0x1D)]
        [InlineData(Chrominance.Black, Luma.Light, 0x2D)]
        [InlineData(Chrominance.Black, Luma.VeryLight, 0x3D)]
        [InlineData(Chrominance.Black2, Luma.Dark, 0x0E)]
        [InlineData(Chrominance.Black3, Luma.Dark, 0x0F)]
        public void Value_BasedOnChromaAndLuma(Chrominance chroma, Luma luma, byte value)
        {
            var color = new Color(chroma, luma);
            Assert.Equal(value, color.Value);
        }

        [Fact]
        public void AllColors_ContainsStaticMembers()
        {
            Assert.Contains(Color.White, Color.GetAllColors());
            Assert.Contains(Color.Black, Color.GetAllColors());
        }

        [Theory]
        [InlineData(Chrominance.Gray, Luma.VeryLight)]
        [InlineData(Chrominance.Black, Luma.Medium)]
        [InlineData(Chrominance.Black2, Luma.Dark)]
        [InlineData(Chrominance.Black2, Luma.Medium)]
        [InlineData(Chrominance.Black2, Luma.Light)]
        [InlineData(Chrominance.Black2, Luma.VeryLight)]
        [InlineData(Chrominance.Black3, Luma.Dark)]
        [InlineData(Chrominance.Black3, Luma.Medium)]
        [InlineData(Chrominance.Black3, Luma.Light)]
        [InlineData(Chrominance.Black3, Luma.VeryLight)]
        public void AllColors_DoesNotContain_DuplicateColors(Chrominance chroma, Luma luma)
        {
            byte value = new Color(chroma, luma).Value;
            IEnumerable<byte> allValues = Color.GetAllColors().Select(c => c.Value);
            Assert.DoesNotContain(value, allValues);
        }

        [Fact]
        public void Color_Throws_IfGreaterThan_0x3F()
        {
            Assert.Equal("Black", new Color(0x3F).Name);
            for (byte b = 0x40; b < 0xFF; b++)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Color(b));
            }
        }

        [Theory]
        [InlineData("Black", Chrominance.Black, Luma.Dark)]
        [InlineData("Darker Gray", Chrominance.Gray, Luma.Dark)]
        [InlineData("Dark Gray", Chrominance.Black, Luma.Light)]
        [InlineData("Gray", Chrominance.Gray, Luma.Medium)]
        [InlineData("Light Gray", Chrominance.Black, Luma.VeryLight)]
        [InlineData("White", Chrominance.Gray, Luma.Light)]
        [InlineData("Brown", Chrominance.Yellow, Luma.Dark)]
        [InlineData("Dark Yellow", Chrominance.Yellow, Luma.Medium)]
        [InlineData("Yellow", Chrominance.Yellow, Luma.Light)]
        [InlineData("Light Yellow", Chrominance.Yellow, Luma.VeryLight)]
        [InlineData("Red", Chrominance.Red, Luma.Medium)]
        [InlineData("Green", Chrominance.Green, Luma.Medium)]
        [InlineData("Blue", Chrominance.Blue, Luma.Medium)]
        [InlineData("Sea Green", Chrominance.SeaGreen, Luma.Medium)]
        public void Parse_ParsesValidNames(string name, Chrominance chroma, Luma luma)
        {
            Color c = Color.Parse(name);
            Assert.Equal(name, c.Name);
            Assert.Equal(chroma, c.Chrominance);
            Assert.Equal(luma, c.Luma);
        }
    }
}
