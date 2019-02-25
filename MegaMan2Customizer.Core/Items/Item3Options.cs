using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core.Items
{
    public class Item3Options : BaseItemOptions
    {
        public Item3Options(byte[] romBytes) : base(romBytes, Addresses.Item3Color1, Addresses.Item3Color2, ItemId.Item3)
        {
        }
    }
}
