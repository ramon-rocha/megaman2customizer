using System;

namespace MegaMan2Customizer.Core
{
    public class QuickBoomerangOptions : BaseWeaponOptions
    {
        public override string Name
        {
            get
            {
                string line1 = Text.DecodeWeaponName(_romBytes, Addresses.QuickBoomerangNameLine1);
                string line2 = Text.DecodeWeaponName(_romBytes, Addresses.QuickBoomerangNameLine2);

                if (line2.Length == 0)
                {
                    return line1;
                }

                if (line1.EndsWith("-") || line2.StartsWith("-"))
                {
                    return line1 + line2;
                }

                if (line1.Length < Defaults.MaxCutSceneTextLength - 2)
                {
                    return $"{line1} {line2}";
                }

                return line1 + line2;
            }
                
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Weapon name cannot be null or empty");
                }
                if (value.Length > Defaults.MaxCutSceneTextLength * 2)
                {
                    throw new ArgumentException($"Weapon name cannot be longer than {Defaults.MaxCutSceneTextLength * 2} characters");
                }

                string line1 = value;
                string line2 = "";

                bool nameFitsOneLine = value.Length <= Defaults.MaxCutSceneTextLength;

                int spaceIndex = value.IndexOf(' ');
                bool hasSpace = spaceIndex > 0;

                int hyphenIndex = value.IndexOf('-');
                bool hasHypehn = hyphenIndex > 0;

                bool nameIsLong = value.Length > Defaults.MaxCutSceneTextLength - 2;
                bool nameCanBeSplit = nameIsLong && (hasSpace || hasHypehn);

                if (!nameFitsOneLine || nameCanBeSplit)
                {
                    int splitIndex = hasSpace ? spaceIndex
                        : hasHypehn ? hyphenIndex
                        : value.Length % 2 == 0 ? value.Length / 2
                        : value.Length / 2 + 1;

                    line1 = value[..splitIndex];
                    line2 = value[splitIndex..];

                    bool line2IsLong = line2.Length > Defaults.MaxCutSceneTextLength - 2;
                    bool line1HasRoom = line1.Length < Defaults.MaxCutSceneTextLength;
                    bool putHypenOnLine1 = hasHypehn && line2IsLong && line1HasRoom;

                    if (putHypenOnLine1)
                    {
                        splitIndex++;
                        line1 = value[..splitIndex];
                        line2 = value[splitIndex..];
                    }

                    bool line1TooLong = line1.Length > Defaults.MaxCutSceneTextLength;
                    bool line2TooLong = line2.Length > Defaults.MaxCutSceneTextLength;

                    if ((hasSpace || hasHypehn) && (line1TooLong || line2TooLong))
                    {
                        // line 1 or line 2 is too long so we can't split on a space or hyphen after all
                        splitIndex = value.Length % 2 == 0 
                            ? value.Length / 2
                            : value.Length / 2 + 1;
                        line1 = value[..splitIndex];
                        line2 = value[splitIndex..];
                    }
                }

                byte[] line1Bytes = Text.EncodeCutScene(line1);
                byte[] line2Bytes = Text.EncodeCutScene(line2);
                line1Bytes.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine1);
                line2Bytes.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine2);
            }
        }

        public byte FireDelay
        {
            get => _romBytes[Addresses.QuickBoomerangFireDelay];
            set => _romBytes[Addresses.QuickBoomerangFireDelay] = value;
        }

        public byte MaxShots
        {
            get => _romBytes[Addresses.QuickBoomerangMaxShots];
            set => _romBytes[Addresses.QuickBoomerangMaxShots] = value;
        }

        public byte ShotsPerAmmo
        {
            get => _romBytes[Addresses.QuickBoomerangShotsPerAmmo];
            set => _romBytes[Addresses.QuickBoomerangShotsPerAmmo] = value;
        }

        public byte TravelDistance
        {
            get => _romBytes[Addresses.QuickBoomerangTravelDistance];
            set => _romBytes[Addresses.QuickBoomerangTravelDistance] = value;
        }

        public byte LaunchAngle
        {
            get => _romBytes[Addresses.QuickBoomerangLaunchAngle];
            set => _romBytes[Addresses.QuickBoomerangLaunchAngle] = value;
        }

        public byte ReturnAngle
        {
            get => _romBytes[Addresses.QuickBoomerangReturnAngle];
            set => _romBytes[Addresses.QuickBoomerangReturnAngle] = value;
        }

        public byte Behavior
        {
            get => _romBytes[Addresses.QuickBoomerangBehavior];
            set => _romBytes[Addresses.QuickBoomerangBehavior] = value;
        }

        public byte FlightTime
        {
            get => _romBytes[Addresses.QuickBoomerangFlightTime];
            set => _romBytes[Addresses.QuickBoomerangFlightTime] = value;
        }

        public QuickBoomerangOptions(byte[] romBytes) : base(
            romBytes,
            primaryColorAddress: Addresses.QuickBoomerangColor1,
            secondaryColorAddress: Addresses.QuickBoomerangColor2,
            weaponNameAddress: Addresses.QuickBoomerangNameLine1,
            cutSceneLetterAddress: Addresses.QuickBoomerangCutSceneLetterCode,
            menuLetterAddress: Addresses.QuickBoomerangMenuLetterCode,
            weaponId: WeaponId.QuickBoomerang)
        {
        }
    }
}
