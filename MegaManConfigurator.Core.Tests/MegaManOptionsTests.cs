using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using MegaMan2Configurator.Core;
using Xunit;

namespace MegaManConfigurator.Core.Tests
{
    public class MegaManOptionsTests
    {
        private readonly ImmutableArray<byte> _romBytes = File.ReadAllBytes("Mega Man II.nes").ToImmutableArray();

        [Theory]
        [InlineData(0x00)]
        public void CanChange_StartingHealth(byte startingHealth)
        {
            var rom = new MegaManRom(_romBytes.ToArray());
            rom.MegaManOptions.StartingHealth = startingHealth;
            string path = "";
            try
            {
                path = Path.GetTempFileName();
                rom.SaveAs(path);
                var modifiedRom = new MegaManRom(path);
                Assert.Equal(startingHealth, rom.MegaManOptions.StartingHealth);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
