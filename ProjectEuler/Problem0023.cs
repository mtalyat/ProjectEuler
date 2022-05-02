using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0023 : Problem
    {
        protected override uint Number => 23;//Michael Jordan who?

        protected override string GetPrompt()
        {
            return @"A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";
        }

        protected override string Solve()
        {
            /*
             * For this problem, we will use a list to keep track of the abundant numbers as we go. This will allow for quick lookup
             * as data is being processed, so there is no repeated lookups.
             * 
             * The key to this algorithm is to search smart for the abundant values. What the algorithm here does, is it starts around half of the current number (i)
             * from the list of abundant numbers. Since we know the list is sorted (automatically, since the data is being processed linearly), the values can be decremented
             * or incremented accordingly to quickly search for a pair of values that will add together to get the current number being checked.
             * 
             * If no value or pairs of abundant numbers is found, it is added to the sum, which is the result.
             */

            const uint limit = 28124;

            List<uint> abundants = new List<uint>();
            double half;
            int leftIndex;
            int rightIndex;
            uint abundantsSum;

            ulong sum = 0;

            for (uint i = 1; i < limit; i++)
            {
                half = i / 2.0;

                leftIndex = -1;
                rightIndex = -1;

                //find left and right abundant numbers
                for(int j = 0; j < abundants.Count; j++)
                {
                    if(abundants[j] > half)
                    {
                        rightIndex = j;
                        leftIndex = j - 1;
                        break;
                    } else if (abundants[j] == half)
                    {
                        rightIndex = j;
                        leftIndex = j;
                        break;
                    }
                }

                if(rightIndex == -1 || leftIndex == -1)
                {
                    //if no right index, this integer cannot be written as the sum of two abundant numbers (all abundant numbers are too low)
                    //OR no lower value, so cannot be written
                    sum += i;
                } else
                {
                    //if it is not any of the above, search
                    abundantsSum = abundants[leftIndex] + abundants[rightIndex];
                    while (abundantsSum != i)
                    {
                        //if lower, shift right up. If higher, shift left down
                        if(abundantsSum > i)
                        {
                            leftIndex--;
                        } else
                        {
                            rightIndex++;
                        }

                        if(leftIndex < 0 || rightIndex >= abundants.Count)
                        {
                            //indices are no longer valid
                            break;
                        }

                        abundantsSum = abundants[leftIndex] + abundants[rightIndex];
                    }

                    if(abundantsSum != i)
                    {
                        //i cannot be made of abundants
                        sum += i;
                    }
                }

                //lastly, add this, if it is abundant
                if (IsAbundant(i))
                {
                    abundants.Add(i);
                }
            }

            return sum.ToString();
        }

        private bool IsAbundant(uint number)
        {
            uint sum = 1;
            uint temp;

            for (uint i = 2; i <= Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    sum += i;
                    temp = number / i;

                    //do not add twice
                    if(temp != i)
                    {
                        sum += temp;
                    }
                }
            }

            return sum > number;
        }
    }
}
