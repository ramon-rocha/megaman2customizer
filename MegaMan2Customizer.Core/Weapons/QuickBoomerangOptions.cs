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

                bool line1TooLong = line1.Length > Defaults.MaxCutSceneTextLength;
                bool line1CanBeSplit = (line1.Contains("-") || line1.Contains(" ")) && line1.Length > Defaults.MaxCutSceneTextLength - 2;

                if (line1TooLong || line1CanBeSplit)
                {
                    int spaceIndex = value.IndexOf(' ');
                    int hyphenIndex = value.IndexOf('-');
                    int splitIndex = value.Contains(" ") ? spaceIndex
                        : value.Contains("-") ? hyphenIndex
                        : value.Length % 2 == 0 ? value.Length / 2
                        : value.Length / 2 + 1;

                    line1 = value.Substring(0, splitIndex);
                    line2 = value.Substring(splitIndex, value.Length - splitIndex);

                    bool hypenCausesMisalignment = hyphenIndex > 0 
                        && line2.Length > Defaults.MaxCutSceneTextLength - 2
                        && line1.Length < Defaults.MaxCutSceneTextLength;

                    if (hypenCausesMisalignment)
                    {
                        // spaces out better to put the hyphen on line 1 in this case
                        splitIndex++;
                        line1 = value.Substring(0, splitIndex);
                        line2 = value.Substring(splitIndex, value.Length - splitIndex);
                    }

                    if ((spaceIndex > 0 || hyphenIndex > 0)
                        && (line1.Length > Defaults.MaxCutSceneTextLength || line2.Length > Defaults.MaxCutSceneTextLength))
                    {
                        // line 1 or line 2 is too long so we can't split on a space or hyphen after all
                        splitIndex = value.Length % 2 == 0 
                            ? value.Length / 2
                            : value.Length / 2 + 1;
                        line1 = value.Substring(0, splitIndex);
                        line2 = value.Substring(splitIndex, value.Length - splitIndex);
                    }
                }

                byte[] line1Bytes = Text.EncodeCutScene(line1);
                byte[] line2Bytes = Text.EncodeCutScene(line2);
                line1Bytes.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine1);
                line2Bytes.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine2);
            }
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
