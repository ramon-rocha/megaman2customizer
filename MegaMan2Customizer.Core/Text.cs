using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        private static readonly IReadOnlyDictionary<byte, char> _cutSceneMap = new Dictionary<byte, char>
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

        private static IReadOnlyDictionary<char, byte> _invertedCutSceneMap = null;

        public static string DecodeWeaponMenu(byte[] bytes, int address, int length) =>
            Decode(_weaponMenuMap, bytes, address, length);

        private static IReadOnlyDictionary<char, byte> InvertedCutSceneMap
        {
            get
            {
                if (_invertedCutSceneMap == null)
                {
                    _invertedCutSceneMap = _cutSceneMap.ToImmutableDictionary(e => e.Value, e => e.Key);
                }
                return _invertedCutSceneMap;
            }
        }

        public static string DecodeCutScene(ImmutableArray<byte> bytes, int address) =>
            DecodeCutScene(bytes.ToArray(), address);

        public static string DecodeCutScene(byte[] bytes, int address) =>
            Decode(_cutSceneMap, bytes, address, Defaults.MaxCutSceneTextLength);

        public static string DecodeWeaponName(byte[] bytes, int address) =>
            DecodeCutScene(bytes, address).Trim();

        private static readonly IReadOnlyDictionary<byte, char> _weaponMenuMap = new Dictionary<byte, char>
        {
            { 0x95, 'N' },
            { 0x96, 'E' },
            { 0x97, 'X' }, // also shows small part of T character
            { 0x98, 'T' }, // slightly off-center
            { 0x99, 'W' },
            { 0x9A, 'F' },
            { 0x9B, 'A' },
            { 0x9C, 'Q' },
            { 0x9D, 'B' },
            { 0x9E, 'M' },
            { 0x9F, 'H' },
            { 0x10, 'C' },
            { 0x11, '→' },
            { 0x12, '►' },
            { 0x13, '○' },
            { 0x48, '●' },
            { 0x14, '0' },
            { 0x15, '1' },
            { 0x16, '2' },
            { 0x17, '3' },
            { 0x18, '4' },
            { 0x19, '5' },
            { 0x1A, '6' },
            { 0x1B, '7' },
            { 0x1C, '8' },
            { 0x1D, '9' },
            { 0x1E, ':' },
            { 0x1F, 'P' },
        }.ToImmutableDictionary();

        private static IReadOnlyDictionary<char, byte> _invertedWeaponMenuMap = null;
        private static IReadOnlyDictionary<char, byte> InvertedWeaponMenuMap
        {
            get
            {
                if (_invertedWeaponMenuMap == null)
                {
                    _invertedWeaponMenuMap = _weaponMenuMap.ToImmutableDictionary(e => e.Value, e => e.Key);
                }
                return _invertedWeaponMenuMap;
            }
        }

        private static IReadOnlyList<char> _weaponLetterCodes = null;

        public static IReadOnlyList<char> WeaponLetterCodes
        {
            get
            {
                if (_weaponLetterCodes == null)
                {
                    _weaponLetterCodes = _cutSceneMap.Values.Intersect(_weaponMenuMap.Values).ToImmutableList();
                }
                return _weaponLetterCodes;
            }
        }

        public static byte[] EncodeCutScene(string text)
        {
            if (text.Length < Defaults.MaxCutSceneTextLength)
            {
                while (!text.StartsWith("  ") && text.Length < Defaults.MaxCutSceneTextLength)
                {
                    text = " " + text;
                }
                while (text.Length < Defaults.MaxCutSceneTextLength)
                {
                    text += " ";
                }
            }
            var bytes = new List<byte>();
            foreach (char c in text)
            {
                byte b = EncodeCutScene(c);
                bytes.Add(b);
            }
            return bytes.ToArray();
        }

        public static byte EncodeWeaponMenu(char value) => InvertedWeaponMenuMap[value];

        public static byte EncodeCutScene(char value) => InvertedCutSceneMap[value];

        private static readonly IReadOnlyDictionary<byte, char> _stageSelectMap = new Dictionary<byte, char>
        {
            { 0x01, 'A' },
            { 0x02, 'B' },
            { 0x03, 'C' },
            { 0x04, 'D' },
            { 0x05, 'E' },
            { 0x06, 'F' },
            { 0x07, 'G' },
            { 0x08, 'H' },
            { 0x09, 'I' },
            { 0x0A, 'J' },
            { 0x0B, 'K' },
            { 0x0C, 'L' },
            { 0x0D, 'M' },
            { 0x0E, 'N' },
            { 0x0F, 'O' },
            { 0x10, 'P' },
            { 0x11, 'Q' },
            { 0x12, 'R' },
            { 0x13, 'S' },
            { 0x14, 'T' },
            { 0x15, 'U' },
            { 0x16, 'V' },
            { 0x17, 'W' },
            { 0x18, 'X' },
            { 0x19, 'Y' },
            { 0x1A, 'Z' },
            { 0x1B, '®' },
            { 0x1C, '.' },
            { 0x1D, ',' },
            { 0x1E, '\'' },
            { 0x1F, '!' },
            { 0x20, ' ' }
        }.ToImmutableDictionary();

        public static string DecodeRobotMasterName(byte[] bytes, int address, int length) =>
            Decode(_stageSelectMap, bytes, address, length);
    }
}
