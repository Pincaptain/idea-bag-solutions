using System;
using System.Collections.Generic;
using System.Linq;

namespace roman_number_generator
{
    public static class RomanNumberGenerator
    {
        private static readonly Dictionary<int, string> RomanDictionary = new Dictionary<int, string>()
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX" },
            { 10, "X" },
            { 40, "XL" },
            { 50, "L" },
            { 90, "XC" },
            { 100, "C" },
            { 400, "CD" },
            { 500, "D" },
            { 900, "CM" },
            { 1000, "M" }
        };

        private static int GetClosestKey(int number)
        {
            return new List<int>(RomanDictionary.Keys)
                .Aggregate((x, y) =>
                {
                    if (Math.Abs(number - y) < Math.Abs(number - x))
                    {
                        return y <= number ? y : x;
                    }

                    return x;
                });
        }

        public static string GenerateRomanNumber(int number)
        {
            var closestKey = GetClosestKey(number);

            return number switch
            {
                1 => RomanDictionary[number],
                0 => string.Empty,
                _ => RomanDictionary[closestKey] + GenerateRomanNumber(number - closestKey)
            };
        }
    }
}