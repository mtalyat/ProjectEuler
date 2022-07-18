using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0010 : Problem
    {
        protected override string GetPrompt()
        {
            return "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\n\n" +
                "Find the sum of all the primes below two million.";
        }

        protected override string Solve()
        {
            /*
             * Straightforward. Similar to Problem 7, except we are summing the first x number of primes, where their values are < 2 million.
             */

            const int count = 2000000;

            List<int> primes = new List<int>();

            //add 2 since we are skipping it
            primes.Add(2);

            long sum = 2;//start with 2 since it was already added

            for (int i = 3; i < count; i += 2)
            {
                //if the number is prime, add it
                if (Helper.IsPrime(i, primes))
                {
                    primes.Add(i);
                    sum += i;
                }
            }

            return sum.ToString();
        }
    }
}
