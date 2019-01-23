using Xunit;

namespace MegaMan2Customizer.Core.Tests
{
    public class ByteArrayExtensionTests
    {
        [Theory]
        [InlineData(new byte[] { 0, 0 }, 0, 1, "0.0")]
        [InlineData(new byte[] { 0, 0, 0 }, 0, 1, "0.0")]
        [InlineData(new byte[] { 0, 0, 0 }, 1, 2, "0.0")]
        [InlineData(new byte[] { 0, 0, 0 }, 0, 2, "0.0")]
        [InlineData(new byte[] { 1, 0, 0 }, 0, 1, "1.0")]
        [InlineData(new byte[] { 1, 0, 0 }, 0, 2, "1.0")]
        [InlineData(new byte[] { 1, 0, 0xFF }, 0, 1, "1.0")]
        [InlineData(new byte[] { 1, 0, 0xFF }, 0, 2, "1.99609375")]
        [InlineData(new byte[] { 1, 0xFF, 0 }, 0, 1, "1.99609375")]
        [InlineData(new byte[] { 1, 0xFF, 0 }, 0, 2, "1.0")]
        [InlineData(new byte[] { 0xFF, 0xFF, 0 }, 0, 2, "255.0")]
        [InlineData(new byte[] { 0xFF, 0xFF, 0 }, 0, 1, "255.99609375")]
        [InlineData(new byte[] { 1, 0x80, 0 }, 0, 1, "1.5")]
        public void GetDecimal_ConvertsTwoBytes(byte[] bytes, int wholeAddress, int fractionAddress, string valueText)
        {
            var value = decimal.Parse(valueText);
            Assert.Equal(value, bytes.GetDecimal(wholeAddress, fractionAddress));
        }
    }
}
