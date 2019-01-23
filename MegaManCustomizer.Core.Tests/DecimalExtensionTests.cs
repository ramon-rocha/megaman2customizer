using System;

using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class DecimalExtensionTests
    {
        [Theory]
        [InlineData("0.0", 0, 0)]
        [InlineData("1.5", 1, 0x80)]
        [InlineData("1.9961", 1, 0xFF)]
        [InlineData("1.9960", 1, 0xFE)]
        [InlineData("255.0", 0xFF, 0)]
        [InlineData("255.99609375", 0xFF, 0xFF)]
        public void ToBytePair(string textValue, byte whole, byte fraction)
        {
            var value = decimal.Parse(textValue);
            (byte whole, byte fraction) pair = value.ToBytePair();
            Assert.Equal(whole, pair.whole);
            Assert.Equal(fraction, pair.fraction);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-0.5")]
        [InlineData("256")]
        [InlineData("1000")]
        public void ToBytePair_ThrowsWhenOutOfRange(string textValue)
        {
            var value = decimal.Parse(textValue);
            Assert.Throws<ArgumentOutOfRangeException>(
                () => value.ToBytePair()
            );
        }
    }
}
