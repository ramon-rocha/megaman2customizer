using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class BaseRobotMasterOptions
    {
        protected readonly byte[] _romBytes;

        protected readonly int _primaryColorAddress;

        protected readonly int _secondaryColorAddress;

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

        public BaseRobotMasterOptions(byte[] romBytes, int primaryColorAddress, int secondaryColorAddress)
        {
            _romBytes = romBytes;
            _primaryColorAddress = primaryColorAddress;
            _secondaryColorAddress = secondaryColorAddress;
        }
    }
}
