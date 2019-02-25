using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core.Items
{
    public class Item1Options : BaseItemOptions
    {
        public Item1Options(byte[] romBytes) : base(romBytes, Addresses.Item1Color1, Addresses.Item1Color2, ItemId.Item1)
        {
        }
    }
}
