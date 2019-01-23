using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MegaMan2Customizer.Core
{
    public enum Brightness
    {
        Dark = 0x00,
        Normal = 0x10,
        Bright = 0x20,
        Pastel = 0x30
    }

    public enum Pigment
    {
        White = 0x00, // bright white and pastel white are the same
        Blue = 0x01,
        Indigo = 0x02,
        Purple = 0x03,
        Pink = 0x04,
        Crimson = 0x05,
        Red = 0x06,
        Orange = 0x07,
        Yellow = 0x08,
        DarkGreen = 0x09,
        Green = 0x0A,
        ForestGreen = 0x0B,
        Cyan = 0x0C,
        Black = 0x0D, // dark black and normal black are the same
    }

    public class Color
    {
        public static readonly Color BrightWhite = new Color(Pigment.White, Brightness.Bright);

        public static readonly Color Black = new Color(Pigment.Black, Brightness.Normal);

        public Pigment Pigment { get; }

        public Brightness Brightness { get; }

        public byte Value => (byte)((int)this.Pigment + (int)this.Brightness);

        public Color(Pigment pigment, Brightness brightness) => 
            (this.Pigment, this.Brightness) = ClampColor(pigment, brightness);

        public Color (byte value)
        {
            if (value > 0x3D)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var brightness = (Brightness)(value & 0xF0);
            var pigment = (Pigment)(value & 0x0F);
            (this.Pigment, this.Brightness) = ClampColor(pigment, brightness);
        }

        private (Pigment, Brightness) ClampColor(Pigment pigment, Brightness brightness)
        {
            if (pigment == Pigment.White && brightness == Brightness.Pastel)
            {
                brightness = Brightness.Bright;
            }
            else if (pigment == Pigment.Black && brightness == Brightness.Dark)
            {
                brightness = Brightness.Normal;
            }

            return (pigment, brightness);
        }

        public string Name
        {
            get
            {
                string pigment = this.Pigment.ToString().Replace("kG", "k G").Replace("tG", "t G");

                if (this.Brightness == Brightness.Normal)
                {
                    return pigment;
                }

                if (this.Pigment == Pigment.White && this.Brightness == Brightness.Dark)
                {
                    return "Gray";
                }

                if (this.Pigment == Pigment.Black)
                {
                    if (this.Brightness == Brightness.Bright)
                    {
                        return "Dark Gray";
                    }

                    if (this.Brightness == Brightness.Pastel)
                    {
                        return "Light Gray";
                    }
                }

                if (this.Pigment == Pigment.DarkGreen)
                {
                    if (this.Brightness == Brightness.Dark)
                    {
                        return "Extra Dark Green";
                    }

                    if (this.Brightness == Brightness.Bright)
                    {
                        return "Lime Green";
                    }

                    if (this.Brightness == Brightness.Pastel)
                    {
                        return "Pastel Lime Green";
                    }
                }

                return $"{this.Brightness} {pigment}";
            }
        }

        private static ImmutableList<Color> _allColors = null;
        public static IEnumerable<Color> GetAllColors()
        {
            if (_allColors == null)
            {
                var colors = new HashSet<Color>();
                foreach (var brightness in (Brightness[])Enum.GetValues(typeof(Brightness)))
                {
                    foreach (var pigment in (Pigment[])Enum.GetValues(typeof(Pigment)))
                    {
                        colors.Add(new Color(pigment, brightness));
                    }
                }
                _allColors = ImmutableList.CreateRange(colors);
            }
            return _allColors;
        }

        public static Color Parse(string name) =>
            GetAllColors().FirstOrDefault(c => c.Name == name) ?? throw new FormatException(nameof(name));

        public override string ToString() => $"{this.Name} ({this.Value})";

        public override bool Equals(object obj) =>
            obj is Color other ? Equals(other) : false;

        public bool Equals(Color other) =>
            other != null && this.Value == other.Value;

        public override int GetHashCode() => this.Value.GetHashCode();
    }
}
