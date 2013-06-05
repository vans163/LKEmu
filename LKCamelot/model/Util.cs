using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
namespace LKCamelot.model
{
    public static class Util
    {
        private static Random m_Random = new Random();

        public static int ToInt32(string value)
        {
            int i;

            if (value.StartsWith("0x"))
                int.TryParse(value.Substring(2), NumberStyles.HexNumber, null, out i);
            else
                int.TryParse(value, out i);

            return i;
        }

        public static int Dice(int numDice, int numSides, int bonus)
        {
            int total = 0;
            for (int i = 0; i < numDice; ++i)
                total += Random(numSides) + 1;
            total += bonus;
            return total;
        }

        public static bool RandomBool()
        {
            return (m_Random.Next(2) == 0);
        }

        public static int RandomMinMax(int min, int max)
        {
            if (min > max)
            {
                int copy = min;
                min = max;
                max = copy;
            }
            else if (min == max)
            {
                return min;
            }

            return min + m_Random.Next((max - min) + 1);
        }

        public static int Random(int from, int count)
        {
            if (count == 0)
            {
                return from;
            }
            else if (count > 0)
            {
                return from + m_Random.Next(count);
            }
            else
            {
                return from - m_Random.Next(-count);
            }
        }

        public static int Random(int count)
        {
            return m_Random.Next(count);
        }

        public static ushort checkUShort(uint value)
        {
            ushort ret = (ushort)value;
            if (value > ushort.MaxValue)
            {
                ret = (ushort)(value / 1000);
            }
            return ret;
        }

        public static bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.ToCharArray().Any(c => c > MaxAnsiCode);
        }
    }
}
