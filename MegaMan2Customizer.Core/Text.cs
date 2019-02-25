using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace MegaMan2Customizer.Core
{
    public static class Text
    {
        private static string Decode(IReadOnlyDictionary<byte, char> map, byte[] bytes, int address, int length)
        {
            var sb = new StringBuilder();
            for (int i = address; i < address + length; i++)
            {
                byte encodedByte = bytes[i];
                char decodedChar = map[encodedByte];
                sb.Append(decodedChar);
            }
            return sb.ToString();
        }

        private static IReadOnlyDictionary<byte, char> _cutSceneMap = new Dictionary<byte, char>
        {
            { 0x40, ' ' },
            { 0x41, 'A' },
            { 0x42, 'B' },
            { 0x43, 'C' },
            { 0x44, 'D' },
            { 0x45, 'E' },
            { 0x46, 'F' },
            { 0x47, 'G' },
            { 0x48, 'H' },
            { 0x49, 'I' },
            { 0x4A, 'J' },
            { 0x4B, 'K' },
            { 0x4C, 'L' },
            { 0x4D, 'M' },
            { 0x4E, 'N' },
            { 0x4F, 'O' },
            { 0x50, 'P' },
            { 0x51, 'Q' },
            { 0x52, 'R' },
            { 0x53, 'S' },
            { 0x54, 'T' },
            { 0x55, 'U' },
            { 0x56, 'V' },
            { 0x57, 'W' },
            { 0x58, 'X' },
            { 0x59, 'Y' },
            { 0x5A, 'Z' },
            { 0x5B, '®' },
            { 0x5C, '.' },
            { 0x5D, ',' },
            { 0x5E, '\'' },
            { 0x5F, '!' },
            { 0x94, '-' },
            { 0xA0, '0' },
            { 0xA1, '1' },
            { 0xA2, '2' },
            { 0xA3, '3' },
            { 0xA4, '4' },
            { 0xA5, '5' },
            { 0xA6, '6' },
            { 0xA7, '7' },
            { 0xA8, '8' },
            { 0xA9, '9' },
        }.ToImmutableDictionary();

        public static string DecodeCutScene(byte[] bytes, int address, int length) =>
            Decode(_cutSceneMap, bytes, address, length);

        public static string DecodeWeaponName(byte[] bytes, int address) =>
            DecodeCutScene(bytes, address, Defaults.MaxWeaponNameLength).Trim();

        public static byte[] EncodeCutScene(string text)
        {
            return text.ToCharArray().Select(c => (byte)c).ToArray();
        }
    }
}
