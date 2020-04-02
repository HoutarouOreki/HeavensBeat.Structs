using System;

namespace HeavensBeat.Structs
{
    public static class MathHelper
    {
        public static int Clamped(this int value, int min, int max) => Math.Min(max, Math.Max(min, value));
        public static decimal Clamped(this decimal value, decimal min, decimal max) => Math.Min(max, Math.Max(min, value));
        public static long Clamped(this long value, long min, long max) => Math.Min(max, Math.Max(min, value));
        public static double Clamped(this double value, double min, double max) => Math.Min(max, Math.Max(min, value));
        public static float Clamped(this float value, float min, float max) => MathF.Min(max, MathF.Max(min, value));

        public static int Squared(this int value) => value * value;
        public static decimal Squared(this decimal value) => value * value;
        public static long Squared(this long value) => value * value;
        public static double Squared(this double value) => value * value;
        public static float Squared(this float value) => value * value;

        public static int ToPowerOf(this int value, int power)
        {
            var returnValue = 1;
            if (power > 0)
                for (var i = 1; i <= power; i++)
                    returnValue *= value;
            else if (power < 0)
                for (var i = 1; i <= power; i++)
                    returnValue /= value;
            return returnValue;
        }

        public static decimal ToPowerOf(this decimal value, int power)
        {
            var returnValue = 1m;
            if (power > 0)
                for (var i = 1; i <= power; i++)
                    returnValue *= value;
            else if (power < 0)
                for (var i = 1; i <= power; i++)
                    returnValue /= value;
            return returnValue;
        }
    }
}
