using Kata;
using System;

Console.WriteLine(RoundAndRound.RoundBy2DecimalPlaces(16.765m));

namespace Kata
{

    public static class RoundAndRound
    {
        public static decimal RoundBy2DecimalPlaces(this decimal number)
        {
            return Math.Round(number, 2, MidpointRounding.AwayFromZero);
        }
    }
}
