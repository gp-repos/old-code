using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomExtensions;

namespace CommonUtils
{
    public static class StaticRandom
    {
        private static Random random = new Random();

        public static int Next()
        {
            return random.Next();
        }

        public static int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static void NextBytes(byte[] buffer)
        {
            random.NextBytes(buffer);
        }

        public static double NextDouble()
        {
            return random.NextDouble();
        }

        public static long NextLong()
        {
            return random.NextLong();
        }

        public static long NextLong(long maxValue)
        {
            return random.NextLong(maxValue);
        }

        public static long NextLong(long minValue, long maxValue)
        {
            return random.NextLong(minValue, maxValue);
        }

        public static DateTime NextDateTime(DateTime minDt, DateTime maxDt)
        {
            return random.NextDateTime(minDt, maxDt);
        }

        public static bool VariantBool(int TrueVar, int FalseVar)
        {
            return (random.Next(0, TrueVar + FalseVar) < TrueVar);
        }


    }
}
