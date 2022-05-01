using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEuler
{
    internal class Problem0016 : Problem
    {
        protected override uint Number => 16;

        protected override string GetPrompt()
        {
            return @"2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2^1000?";
        }

        protected override string Solve()
        {
            /*
             * We can again use BigInteger for this calculation. Call Pow on it, then turn it into a strung, turn those digits into integers, then add them together. 
             * 
             * Simple.
             */

            return BigInteger.Pow(2, 1000)
                .ToString()
                .Select(c => int.Parse(c.ToString()))
                .Sum()
                .ToString();
        }
    }
}
