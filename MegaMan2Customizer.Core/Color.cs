using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MegaMan2Customizer.Core
{
    public enum Lightness
    {
        Dark = 0x00,
        Normal = 0x10,
        Light = 0x20,
        VeryLight = 0x30
    }

    public enum Pigment
    {
        White = 0x00, // bright white and pastel white are the same, (rename to gray?)
        Blue = 0x01,
        Indigo = 0x02,
        Violet = 0x03,
        Magenta = 0x04,
        Crimson = 0x05,
        Red = 0x06,
        Orange = 0x07,
        Yellow = 0x08, // the brightness is shifted one category for yellow since we will call dark yellow brown
        SeaGreen = 0x09,
        Green = 0x0A,
        ForestGreen = 0x0B,
        Cyan = 0x0C,
        Black = 0x0D, // dark black and normal black are the same
    }

    public class Color
    {
        public static readonly Color White = new Color(Pigment.White, Lightness.Light);

        public static readonly Color Black = new Color(Pigment.Black, Lightness.Normal);

        public Pigment Pigment { get; }

        public Lightness Lightness { get; }

        public byte Value => (byte)((int)this.Pigment + (int)this.Lightness);

        public Color(Pigment pigment, Lightness lightness) =>
            (this.Pigment, this.Lightness) = ClampColor(pigment, lightness);

        public Color(byte value)
        {
            if (value > 0x3D)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var lightness = (Lightness)(value & 0xF0);
            var pigment = (Pigment)(value & 0x0F);
            (this.Pigment, this.Lightness) = ClampColor(pigment, lightness);
        }

        private (Pigment, Lightness) ClampColor(Pigment pigment, Lightness lightness)
        {
            if (pigment == Pigment.White && lightness == Lightness.VeryLight)
            {
                lightness = Lightness.Light;
            }
            else if (pigment == Pigment.Black && lightness == Lightness.Dark)
            {
                lightness = Lightness.Normal;
            }

            return (pigment, lightness);
        }

        public override bool Equals(object obj) =>
            obj is Color other ? Equals(other) : false;

        public bool Equals(Color other) =>
            other != null && this.Name == other.Name;

        public override int GetHashCode() => this.Name.GetHashCode();

        private readonly static IReadOnlyDictionary<byte, string> _specialNamedColors = new Dictionary<byte, string>
        {
            { 0x00, "Dark Gray" },
            { 0x10, "Light Gray" },
            { 0x20, "White" },
            { 0x30, "White" },
            { 0x0D, "Black" },
            { 0x2D, "Dark Gray" }, // slightly darker than 0x00 but only if measured
            { 0x3D, "Gray" },
            { 0x08, "Brown"},
            { 0x18, "Dark Yellow"},
            { 0x28, "Yellow"},
            { 0x38, "Light Yellow"},
        }.ToImmutableDictionary();

        public string Name
        {
            get
            {
                if (_specialNamedColors.TryGetValue(this.Value, out string name))
                {
                    return name;
                }

                string pigment = this.Pigment.ToString()
                    .Replace("kG", "k G")
                    .Replace("tG", "t G")
                    .Replace("aG", "a G");

                if (this.Lightness == Lightness.Normal)
                {
                    return pigment;
                }

                string lightness = this.Lightness.ToString()
                    .Replace("yL", "y L");

                return $"{lightness} {pigment}";
            }
        }

        private static ImmutableList<Color> _allColors = null;
        public static IEnumerable<Color> GetAllColors()
        {
            if (_allColors == null)
            {
                var colors = new HashSet<Color>();
                foreach (var brightness in (Lightness[])Enum.GetValues(typeof(Lightness)))
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
    }
}
