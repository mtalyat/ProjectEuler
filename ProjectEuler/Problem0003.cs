using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0003 : Problem
    {
        protected override uint Number => 3;

        protected override string GetPrompt()
        {
            return "The prime factors of 13195 are 5, 7, 13 and 29.\n\n" +
                "What is the largest prime factor of the number 600851475143?";
        }

        protected override string Solve()
        {
            /*
             * This takes wayyyy too long to brute force. But there's not much of an option here.
             * 
             * The plan?
             * 
             * Do math. Then do code.
             * 
             *              Math:
             *              
             *      Any number, when trying to find the factors, you divide the value by a number (1, for example). 
             *      If it is evenly divisable, it is a factor. Then add 1 and keep going.
             *      In this situation, value pairs start repeating after the square root of the value.
             *      
             *      For instance, with 36 (sqrt is 6)
             *      
             *      (1, 36), (2, 18), (3, 13), (4, 9), (6, 6), (9, 4)... etc.
             *      
             *      So, we can see that once it hits the square root of the value, it can be ignored.
             *      
             *      Now all we have to do is get the pairs, and check both values, then we are done.
             */

            const ulong count = 600851475143;
            ulong sqrtCount = (ulong)Math.Sqrt(count);

            ulong largestPrime = 1;
            ulong j;
            
            for (ulong i = 1; i <= sqrtCount; i++)
            {
                //first check if the number is a factor
                if(count % i == 0)
                {
                    //get the other half of the pair
                    j = count / i;

                    //check i
                    if(i > largestPrime && IsPrime(i))
                    {
                        largestPrime = i;
                    }

                    //check j
                    if (j > largestPrime && IsPrime(j))
                    {
                        largestPrime = j;
                    }
                }
            }

            return largestPrime.ToString();
        }

        //checks if the given value is a prime number.
        private bool IsPrime(ulong value)
        {
            if (value <= 1) return false;
            if (value == 2) return true;
            if (value % 2 == 0) return false;//eliminate half the numbers

            //get the max number that could multiply into this number
            ulong boundary = (ulong)Math.Floor(Math.Sqrt(value));

            //skip past 0, 1 and 2 since those have been checked
            for (ulong i = 3; i <= boundary; i += 2)
            {
                if(value % i == 0)
                {
                    //if the number checking goes into the value, not prime
                    return false;
                }
            }

            //no numbers went into this value
            return true;
        }
    }
}
