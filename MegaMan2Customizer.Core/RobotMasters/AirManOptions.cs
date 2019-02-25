using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MegaMan2Customizer.Core
{
    public class Tornado
    {
        private readonly byte[] _romBytes;
        private readonly int _vertWholeAddress;
        private readonly int _vertFractionAddress;
        private readonly int _horzWholeAddress;
        private readonly int _horzFractionAddress;
        private readonly int _flightTimeAddress;

        public decimal VerticalVelocity
        {
            get => _romBytes.GetDecimal(_vertWholeAddress, _vertFractionAddress);
            set => _romBytes.SetDecimal(_vertWholeAddress, _vertFractionAddress, value);
        }

        public decimal HorizontalVelocity
        {
            get => _romBytes.GetDecimal(_horzWholeAddress, _horzFractionAddress);
            set => _romBytes.SetDecimal(_horzWholeAddress, _horzFractionAddress, value);
        }

        public byte FlightTime
        {
            get => _romBytes[_flightTimeAddress];
            set => _romBytes[_flightTimeAddress] = value;
        }

        public Tornado(byte[] romBytes, int patternIndex, int tornadoIndex)
        {
            if (patternIndex < 0 || patternIndex > 4)
            {
                throw new IndexOutOfRangeException(nameof(patternIndex));
            }

            if (tornadoIndex < 0 || tornadoIndex > 5)
            {
                throw new IndexOutOfRangeException(nameof(tornadoIndex));
            }

            _romBytes = romBytes;
            int offset = patternIndex * 6 + tornadoIndex;
            _vertWholeAddress = Addresses.AirManTornadoVertSpeedWhole0 + offset;
            _vertFractionAddress = Addresses.AirManTornadoVertSpeedFraction0 + offset;
            _horzWholeAddress = Addresses.AirManTornadoHorzSpeedWhole0 + offset;
            _horzFractionAddress = Addresses.AirManTornadoHorzSpeedFraction0 + offset;
            _flightTimeAddress = Addresses.AirManTornadoFlightTime0 + offset;
        }
    }

    public class TornadoPattern
    {
        public IReadOnlyList<Tornado> Tornados { get; }

        public TornadoPattern(IEnumerable<Tornado> tornados) =>
            this.Tornados = ImmutableList.CreateRange(tornados);
    }

    public class AirManOptions : BaseRobotMasterOptions
    {
        public Color TornadoPrimaryColor
        {
            get => new Color(_romBytes[Addresses.AirManProjectileColor1]);
            set => _romBytes[Addresses.AirManProjectileColor1] = value.Value;
        }

        public Color TornadoSecondaryColor
        {
            get => new Color(_romBytes[Addresses.AirManProjectileColor2]);
            set => _romBytes[Addresses.AirManProjectileColor2] = value.Value;
        }

        public byte ShotsBeforeJumping
        {
            get => _romBytes[Addresses.AirManShotsBeforeJumping];
            set => _romBytes[Addresses.AirManShotsBeforeJumping] = value;
        }

        public decimal Jump1Distance
        {
            get => _romBytes.GetDecimal(Addresses.AirManJump1DistanceWhole, Addresses.AirManJump1DistanceFraction);
            set => _romBytes.SetDecimal(Addresses.AirManJump1DistanceWhole, Addresses.AirManJump1DistanceFraction, value);
        }

        public decimal Jump1Height
        {
            get => _romBytes.GetDecimal(Addresses.AirManJump1HeightWhole, Addresses.AirManJump1HeightFraction);
            set => _romBytes.SetDecimal(Addresses.AirManJump1HeightWhole, Addresses.AirManJump1HeightFraction, value);
        }

        public decimal Jump2Distance
        {
            get => _romBytes.GetDecimal(Addresses.AirManJump2DistanceWhole, Addresses.AirManJump2DistanceFraction);
            set => _romBytes.SetDecimal(Addresses.AirManJump2DistanceWhole, Addresses.AirManJump2DistanceFraction, value);
        }

        public decimal Jump2Height
        {
            get => _romBytes.GetDecimal(Addresses.AirManJump2HeightWhole, Addresses.AirManJump2HeightFraction);
            set => _romBytes.SetDecimal(Addresses.AirManJump2HeightWhole, Addresses.AirManJump2HeightFraction, value);
        }

        public IReadOnlyList<TornadoPattern> Patterns { get; }

        public AirManOptions(byte[] romBytes) : base(romBytes, Addresses.AirManColor1, Addresses.AirManColor2, Addresses.AirManWeaponOnDefeat, Addresses.AirManItemOnDefeat)
        {
            var patterns = new List<TornadoPattern>(5);
            for (int i = 0; i < 5; i++)
            {
                var tornadoes = new List<Tornado>(6);
                for (int j = 0; j < 6; j++)
                {
                    tornadoes.Add(new Tornado(romBytes, i, j));
                }
                patterns.Add(new TornadoPattern(tornadoes));
            }
            this.Patterns = patterns.ToImmutableList();
        }
    }
}
