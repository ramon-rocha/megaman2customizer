using System;

namespace MegaMan2Customizer.Core
{
    public static class Extensions
    {
        public static decimal GetDecimal(this byte[] bytes, int wholeAddress, int fractionAddress)
        {
            (byte, byte) pair = (bytes[wholeAddress], bytes[fractionAddress]);
            return pair.ToDecimal();
        }

        public static decimal ToDecimal(this (byte whole, byte faction) bytePair)
        {
            decimal whole = bytePair.whole;
            decimal fraction = bytePair.faction / 256m;
            return whole + fraction;
        }

        public static (byte whole, byte fraction) ToBytePair(this decimal value)
        {
            if (value < 0 || value >= 256)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            decimal whole = Math.Truncate(value);
            decimal fraction = value - whole;
            fraction *= 256;
            return ((byte)whole, (byte)fraction);
        }

    }
}
