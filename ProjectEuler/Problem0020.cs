using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEuler
{
    internal class Problem0020 : Problem
    {
        protected override uint Number => 20;

        protected override string GetPrompt()
        {
            return @"n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!";
        }

        protected override string Solve()
        {
            /*
             * Again, this can be accomplished using BigInteger.
             * 
             * Calculate the factorial, then convert it to a string, add all the digits together, and then show that result.
             */

            return Factorial(100).ToString().Select(c => int.Parse(c.ToString())).Sum().ToString();
        }

        private BigInteger Factorial(BigInteger n)
        {
            //base case
            if(n <= 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
