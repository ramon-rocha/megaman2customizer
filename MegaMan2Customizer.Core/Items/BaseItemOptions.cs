using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public enum ItemId
    {
        None = 0x00,
        Item1 = 0x01,
        Item2 = 0x02,
        Item3 = 0x04
    }

    public abstract class BaseItemOptions
    {
        protected readonly byte[] _romBytes;

        private readonly int _primaryColorAddress;

        private readonly int _secondaryColorAddress;

        public virtual Color PrimaryColor
        {
            get => new Color(_romBytes[_primaryColorAddress]);
            set => _romBytes[_primaryColorAddress] = value.Value;
        }

        public virtual Color SecondaryColor
        {
            get => new Color(_romBytes[_secondaryColorAddress]);
            set => _romBytes[_secondaryColorAddress] = value.Value;
        }

        public ItemId ItemId { get; }

        public BaseItemOptions(byte[] romBytes, int primaryColorAddress, int secondaryColorAddress, ItemId itemId)
        {
            if (itemId == ItemId.None)
            {
                throw new ArgumentException($"Cannot instatiate item when {nameof(itemId)} is {ItemId.None}");
            }

            _romBytes = romBytes;
            _primaryColorAddress = primaryColorAddress;
            _secondaryColorAddress = secondaryColorAddress;
            this.ItemId = itemId;
        }
    }
}
