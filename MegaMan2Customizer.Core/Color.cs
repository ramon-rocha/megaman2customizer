using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MegaMan2Customizer.Core
{
    /// <summary>
    /// In video, luma indicates the brightness of an image.
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/Luma_(video)</remarks>
    public enum Luma
    {
        Dark = 0x00,
        Medium = 0x10,
        Light = 0x20,
        VeryLight = 0x30
    }

    /// <summary>
    /// In video, chrominance is used to encode the color of an image.
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/Chrominance</remarks>
    public enum Chrominance
    {
        Gray = 0x00, // light gray and very light gray are both white
        Blue = 0x01,
        Indigo = 0x02,
        Violet = 0x03,
        Magenta = 0x04,
        Crimson = 0x05,
        Red = 0x06,
        Orange = 0x07,
        Yellow = 0x08, // For naming purposes, we will shift the luma by one since medium yellow appears as a dark yellow.  We will refer to dark yellow as brown.
        SeaGreen = 0x09,
        Green = 0x0A,
        ForestGreen = 0x0B,
        Cyan = 0x0C,
        Black = 0x0D, // dark black and medium black are the same
        Black2 = 0x0E, // always black regardless of luma
        Black3 = 0x0F, // always black regardless of luma
    }

    // color_test.nes ROM by rainwarrior: http://forums.nesdev.com/viewtopic.php?f=3&t=13264&p=155593#p155593

    /// <summary>
    /// A color value is composed of a luma and chroma value
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/List_of_video_game_console_palettes#NES</remarks>
    public class Color
    {
        public static readonly Color White = new Color(Chrominance.Gray, Luma.Light);

        public static readonly Color Black = new Color(Chrominance.Black, Luma.Dark);

        private static ImmutableList<Color> _allColors = null;
        public static IEnumerable<Color> GetAllColors()
        {
            if (_allColors == null)
            {
                var allColors = new HashSet<Color>();
                for (byte chroma = 0x00; chroma <= 0x0F; chroma += 0x01)
                {
                    for (byte luma = 0x00; luma <= 0x30; luma += 0x10)
                    {
                        var value = (byte)(luma + chroma);
                        allColors.Add(new Color(value));
                    }
                }
                _allColors = allColors.ToImmutableList();
            }
            return _allColors;
        }

        public static Color Parse(string name) =>
            GetAllColors().FirstOrDefault(c => c.Name == name) ?? throw new FormatException(nameof(name));

        public Chrominance Chrominance { get; }

        public Luma Luma { get; }

        public byte Value => (byte)((int)this.Chrominance + (int)this.Luma);

        public Color(Chrominance chroma, Luma luma) =>
            (this.Chrominance, this.Luma) = (chroma, luma);

        public Color(byte value)
        {
            if (value > 0x3F)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var luma = (Luma)(value & 0xF0);
            var chroma = (Chrominance)(value & 0x0F);
            (this.Chrominance, this.Luma) = (chroma, luma);
        }

        private readonly static IReadOnlyDictionary<byte, string> _specialNamedColors = new Dictionary<byte, string>
        {
            { 0x00, "Darker Gray" }, // slightly darker than 0x2D but only if measured
            { 0x10, "Gray" },
            { 0x20, "White" },
            { 0x30, "White" },
            { 0x0D, "Black" },
            { 0x2D, "Dark Gray" },
            { 0x3D, "Light Gray" },
            { 0x08, "Brown"},
            { 0x18, "Dark Yellow"},
            { 0x28, "Yellow"},
            { 0x38, "Light Yellow"},
        }.ToImmutableDictionary();

        public string Name
        {
            get
            {
                if (this.Chrominance == Chrominance.Black2 || this.Chrominance == Chrominance.Black3)
                {
                    return "Black";
                }

                if (_specialNamedColors.TryGetValue(this.Value, out string name))
                {
                    return name;
                }

                string chroma = this.Chrominance.ToString()
                    .Replace("kG", "k G")
                    .Replace("tG", "t G")
                    .Replace("aG", "a G");

                if (this.Luma == Luma.Medium)
                {
                    return chroma;
                }

                string luma = this.Luma.ToString().Replace("yL", "y L");
                return $"{luma} {chroma}";
            }
        }

        public override string ToString() => $"{this.Name} ({this.Value})";

        public override int GetHashCode() => this.Name.GetHashCode();

        public override bool Equals(object obj) =>
            obj is Color other ? Equals(other) : false;

        public bool Equals(Color other) =>
            other != null && this.Name == other.Name;
    }
}
