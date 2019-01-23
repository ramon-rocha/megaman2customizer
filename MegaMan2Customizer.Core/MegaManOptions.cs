using System.Collections.Generic;

namespace MegaMan2Customizer.Core
{
    public class MegaManOptions
    {
        private readonly byte[] _romBytes;

        public byte StartingHealth
        {
            get => _romBytes[Addresses.MegaManStartingHealth];
            set => _romBytes[Addresses.MegaManStartingHealth] = value;
        }

        public byte MaxHealth
        {
            get => _romBytes[Addresses.MegaManMaxHealth];
            set => _romBytes[Addresses.MegaManMaxHealth] = value;
        }

        public byte MaxBusterShots
        {
            get => _romBytes[Addresses.MegaManBusterMaxShots];
            set => _romBytes[Addresses.MegaManBusterMaxShots] = value;
        }

        public byte BusterSpeed
        {
            get => _romBytes[Addresses.MegaManBusterSpeed];
            set => _romBytes[Addresses.MegaManBusterSpeed] = value;
        }

        public byte Speed // TODO: include fractional component
        {
            get => _romBytes[Addresses.MegaManWalkSpeed];
            set => _romBytes[Addresses.MegaManWalkSpeed] = _romBytes[Addresses.MegaManJumpHorizontalSpeed] = value;
        }

        public decimal LadderClimbSpeed
        {
            get => _romBytes.GetDecimal(Addresses.MegaManLadderClimbSpeedWhole, Addresses.MegaManLadderClimbSpeedFraction);
            set
            {
                (byte whole, byte fraction) = value.ToBytePair();
                _romBytes[Addresses.MegaManLadderClimbSpeedWhole] = whole;
                _romBytes[Addresses.MegaManLadderClimbSpeedFraction] = fraction;
            }
        }

        public decimal LadderDescentSpeed
        {
            get => _romBytes.GetDecimal(Addresses.MegaManLadderDescentSpeedWhole, Addresses.MegaManLadderDescentSpeedFraction);
            set
            {
                (byte whole, byte fraction) = value.ToBytePair();
                _romBytes[Addresses.MegaManLadderDescentSpeedWhole] = whole;
                _romBytes[Addresses.MegaManLadderDescentSpeedFraction] = fraction;
            }
        }

        public byte JumpHeight
        {
            get => _romBytes[Addresses.MegaManJumpHeight];
            set => _romBytes[Addresses.MegaManJumpHeight] = value;
        }
        public Color BusterPrimaryColor
        {
            get => new Color(_romBytes[Addresses.BusterColor1]);
            set => _romBytes[Addresses.BusterColor1] = value.Value;
        }

        public Color BusterSecondaryColor
        {
            get => new Color(_romBytes[Addresses.BusterColor2]);
            set => _romBytes[Addresses.BusterColor2] = value.Value;
        }

        public MegaManOptions(byte[] romBytes) => _romBytes = romBytes;
    }
}
