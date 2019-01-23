using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public class AirManOptions : BaseRobotMasterOptions
    {
        public byte ShotsBeforeJumping
        {
            get => _romBytes[Addresses.AirManShotsBeforeJumping];
            set => _romBytes[Addresses.AirManShotsBeforeJumping] = value;
        }

        public byte Jump1Distance
        {
            get => _romBytes[Addresses.AirManJump1Distance];
            set => _romBytes[Addresses.AirManJump1Distance] = value;
        }

        public byte Jump2Distance
        {
            get => _romBytes[Addresses.AirManJump2Distance];
            set => _romBytes[Addresses.AirManJump2Distance] = value;
        }

        public byte Jump1Height
        {
            get => _romBytes[Addresses.AirManJump1Height];
            set => _romBytes[Addresses.AirManJump1Height] = value;
        }

        public byte Jump2Height
        {
            get => _romBytes[Addresses.AirManJump2Height];
            set => _romBytes[Addresses.AirManJump2Height] = value;
        }

        /// <summary>
        /// The number of entries in the table of tornado projectile data
        /// </summary>
        public const int MaxNumberOfTornadoes = 30;

        public byte GetTornadoVerticalSpeed(int i)
        {
            if (i < 0 || i >= MaxNumberOfTornadoes)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            return _romBytes[Addresses.AirManTornadoVertSpeed0 + i];
        }

        public void SetTornadoVerticalSpeed(int i, byte value)
        {
            if (i < 0 || i >= MaxNumberOfTornadoes)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            _romBytes[Addresses.AirManTornadoVertSpeed0 + i] = value;
        }

        public byte GetTornadoHorizontalSpeed(int i)
        {
            if (i < 0 || i >= MaxNumberOfTornadoes)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            return _romBytes[Addresses.AirManTornadoHorzSpeed0 + i];
        }

        public void SetTornadoHorizontalSpeed(int i, byte value)
        {
            if (i < 0 || i >= MaxNumberOfTornadoes)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            _romBytes[Addresses.AirManTornadoHorzSpeed0 + i] = value;
        }

        public byte GetTornadoFlightTime(int i)
        {
            if (i < 0 || i >= MaxNumberOfTornadoes)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            return _romBytes[Addresses.AirManTornadoFlightTime0 + i];
        }

        public void SetTornadoFlightTime(int i, byte value)
        {
            if (i < 0 || i >= MaxNumberOfTornadoes)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            _romBytes[Addresses.AirManTornadoFlightTime0 + i] = value;
        }

        public AirManOptions(byte[] romBytes) : base (romBytes, Addresses.AirManColor1, Addresses.AirManColor2)
        {
        }
}
}
