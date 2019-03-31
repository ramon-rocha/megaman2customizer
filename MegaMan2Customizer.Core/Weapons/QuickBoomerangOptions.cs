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
                
                if (value.Length < Defaults.MaxCutSceneTextLength - 2)
                {
                    byte[] line1 = Text.EncodeCutScene(value);
                    byte[] line2 = Text.EncodeCutScene("");
                    line1.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine1);
                    line2.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine2);
                }
                else
                {
                    int spaceIndex = value.IndexOf(' ');
                    int hyphenIndex = value.IndexOf('-');
                    int index = value.Contains(" ") ? spaceIndex
                        : value.Contains("-") ? hyphenIndex
                        : value.Length % 2 == 0 ? value.Length / 2
                        : value.Length / 2 + 1;

                    string line1 = value.Substring(0, index);
                    string line2 = value.Substring(index, value.Length - index);

                    bool hypenOnLine1 = hyphenIndex > 0 
                        && line2.Length > Defaults.MaxCutSceneTextLength - 2
                        && line1.Length < Defaults.MaxCutSceneTextLength;

                    if (hypenOnLine1)
                    {
                        // spaces out better to put the hyphen on line 1 in this case
                        index++;
                        line1 = value.Substring(0, index);
                        line2 = value.Substring(index, value.Length - index);
                    }

                    if ((spaceIndex > 0 || hyphenIndex > 0)
                        && (line1.Length > Defaults.MaxCutSceneTextLength || line2.Length > Defaults.MaxCutSceneTextLength))
                    {
                        // line 1 or line 2 is too long so we can't split on a space or hyphen after all
                        index = value.Length % 2 == 0 
                            ? value.Length / 2
                            : value.Length / 2 + 1;
                        line1 = value.Substring(0, index);
                        line2 = value.Substring(index, value.Length - index);
                    }

                    byte[] line1Bytes = Text.EncodeCutScene(line1);
                    byte[] line2Bytes = Text.EncodeCutScene(line2);
                    line1Bytes.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine1);
                    line2Bytes.CopyTo(_romBytes, Addresses.QuickBoomerangNameLine2);
                }
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
