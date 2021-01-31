using System;

namespace roman_number_generator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out var number);

            Console.WriteLine(RomanNumberGenerator.GenerateRomanNumber(number));
        }
    }
}