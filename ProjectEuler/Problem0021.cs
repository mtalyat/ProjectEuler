using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0021 : Problem
    {
        protected override uint Number => 21;

        protected override string GetPrompt()
        {
            return @"Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a != b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.";
        }

        protected override string Solve()
        {
            /*
             * I think the best way to accomplish this problem is to use a Dictionary. 
             * It would be the best way to avoid recalculating numbers multiple times.
             * 
             * After writing the code, that is the correct solution.
             */

            const uint count = 10000;

            uint v;
            uint sum;
            uint totalSum = 0;
            Dictionary<uint, uint> dict = new Dictionary<uint, uint>();

            for (uint i = 1; i < count; i++)
            {
                //only do something if it has not been added
                if(!dict.ContainsKey(i))
                {
                    //the value has not yet been set
                    //get the factors, then sum and add to value

                    sum = GetSumOfFactors(i);
                    dict.Add(i, sum);

                    //check if the sum exists, and is not equal to itself
                    if (i != sum && dict.TryGetValue(sum, out v))
                    {

                        //the other value has already been added. If it matches, add to total sum
                        if (i == v)
                        {
                            totalSum += i + sum;
                        }
                    }
                }
            }

            return totalSum.ToString();
        }

        private uint GetSumOfFactors(uint number)
        {
            //1 is special
            if(number < 1)
            {
                return 0;
            } else if (number == 1)
            {
                return 1;
            }

            uint sum = 0;
            uint temp;

            for (uint i = 1; i <= Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    //add pair
                    sum += i;
                    temp = number / i;
                    
                    //only add other part of the pair if it is not the same number
                    if(temp != i && temp != number)
                    {
                        sum += temp;
                    }
                }
            }

            return sum;
        }
    }
}
