using System;

namespace MegaMan2Customizer.Core
{
    public class AirManStageOptions
    {
        protected readonly byte[] _romBytes;

        private static readonly char[] _lineBreaks = new[] { '\n', '\r' };

        public string Name
        {
            get => $"{this.NameLine1}\n{this.NameLine2}";
            set
            {
                string[] lines = value.Split(_lineBreaks, StringSplitOptions.RemoveEmptyEntries);

                string line1 = lines[0];
                string line2 = lines[1];

                bool needsWhiteSpacePadding = line1.Length + line2.Length < Defaults.MaxCutSceneTextLength;
                if (needsWhiteSpacePadding)
                {
                    // left-align line1, right-align line2
                    int maxLineLength = Defaults.MaxStageNameLength / 2;
                    bool textWillOverlap = line1.Length + line2.Length > maxLineLength;
                    if (!textWillOverlap)
                    {
                        int padAmount = maxLineLength - (line1.Length + line2.Length) + 1;
                        if (padAmount % 2 == 0)
                        {
                            line1 = line1.PadLeft(line1.Length + padAmount / 2);
                            line2 = line2.PadRight(line2.Length + padAmount / 2);
                        }
                        else
                        {
                            // extra space goes to shorter line
                            if (line1.Length <= line2.Length)
                            {
                                line1 = line1.PadLeft(line1.Length + (padAmount + 1) / 2);
                                line2 = line2.PadRight(line2.Length + padAmount / 2);
                            }
                            else
                            {
                                line1 = line1.PadLeft(line1.Length + padAmount / 2);
                                line2 = line2.PadRight(line2.Length + (padAmount + 1) / 2);
                            }
                        }
                    }

                    line1 = line1.PadRight(maxLineLength);
                    line2 = line2.PadLeft(maxLineLength);
                }

                this.NameLine1 = line1;
                this.NameLine2 = line2;
            }
        }

        public string NameLine1
        {
            get => Text.DecodeStageName(_romBytes, Addresses.AirManNameStageSelect1);
            set => Text.EncodeStageName(value).CopyTo(_romBytes, Addresses.AirManNameStageSelect1);
        }

        public string NameLine2
        {
            get => Text.DecodeStageName(_romBytes, Addresses.AirManNameStageSelect2);
            set => Text.EncodeStageName(value).CopyTo(_romBytes, Addresses.AirManNameStageSelect2);
        }

        public Color SkyColor
        {
            get => new Color(_romBytes[Addresses.AirStageSkyColor]);
            set
            {
                _romBytes[Addresses.AirStageSkyColor] = value.Value;
                // TODO: find the address for goblin's background
            }

        }

        public Color CloudColor
        {
            get => new Color(_romBytes[Addresses.AirStageCloudColorFrame0]);
            set
            {
                byte v = value.Value;
                _romBytes[Addresses.AirStageCloudColorFrame0] = v;
                _romBytes[Addresses.AirStageCloudColorFrame1] = v;
                _romBytes[Addresses.AirStageCloudColorFrame2] = v;
                _romBytes[Addresses.AirStageCloudColorFrame3] = v;
                _romBytes[Addresses.AirStageCloudColorFrame4] = v;

                _romBytes[Addresses.AirStageCloudInnerBorderColorFrame2] = v;
                _romBytes[Addresses.AirStageCloudInnerBorderColorFrame3] = v;
                _romBytes[Addresses.AirStageCloudInnerBorderColorFrame4] = v;

                _romBytes[Addresses.AirStageCloudOuterBorderColorFrame3] = v;
            }
        }

        public Color CloudInnerBorderColor
        {
            get => new Color(_romBytes[Addresses.AirStageCloudInnerBorderColorFrame0]);
            set
            {
                byte v = value.Value;
                _romBytes[Addresses.AirStageCloudInnerBorderColorFrame0] = v;
                _romBytes[Addresses.AirStageCloudInnerBorderColorFrame1] = v;

                _romBytes[Addresses.AirStageCloudOuterBorderColorFrame2] = v;
                _romBytes[Addresses.AirStageCloudOuterBorderColorFrame4] = v;
            }
        }

        public Color CloudOuterBorderColor
        {
            get => new Color(_romBytes[Addresses.AirStageCloudOuterBorderColorFrame0]);
            set
            {
                byte v = value.Value;
                _romBytes[Addresses.AirStageCloudOuterBorderColorFrame0] = v;
                _romBytes[Addresses.AirStageCloudOuterBorderColorFrame1] = v;
            }
        }

        public Color PlatformTotemColor1
        {
            get => new Color(_romBytes[Addresses.AirStagePlatformTotemColor1Frame0]);
            set
            {
                byte v = value.Value;
                _romBytes[Addresses.AirStagePlatformTotemColor1Frame0] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor1Frame1] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor1Frame2] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor1Frame3] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor1Frame4] = v;
            }
        }

        public Color PlatformTotemColor2
        {
            get => new Color(_romBytes[Addresses.AirStagePlatformTotemColor2Frame0]);
            set
            {
                byte v = value.Value;
                _romBytes[Addresses.AirStagePlatformTotemColor2Frame0] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor2Frame1] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor2Frame2] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor2Frame3] = v;
                _romBytes[Addresses.AirStagePlatformTotemColor2Frame4] = v;
            }
        }

        public Color PlatformShineColor
        {
            get => new Color(_romBytes[Addresses.AirStagePlatformShineColorFrame0]);
            set
            {
                byte v = value.Value;
                _romBytes[Addresses.AirStagePlatformShineColorFrame0] = v;
                _romBytes[Addresses.AirStagePlatformShineColorFrame1] = v;
                _romBytes[Addresses.AirStagePlatformShineColorFrame2] = v;
                _romBytes[Addresses.AirStagePlatformShineColorFrame3] = v;
                _romBytes[Addresses.AirStagePlatformShineColorFrame4] = v;
            }
        }

        public AirManStageOptions(byte[] romBytes) => _romBytes = romBytes;
    }
}
