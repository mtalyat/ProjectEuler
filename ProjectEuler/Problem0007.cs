using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0007 : Problem
    {
        protected override uint Number => 7;

        protected override string GetPrompt()
        {
            return "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.\nWhat is the 10 001st prime number ?";
        }

        protected override string Solve()
        {
            /*
             * For this problem, we want to find the 10001st prime number. The naive approach is to start at 2, add one and check if each number is prime.
             * If it is, add to and index so we know how many we have found, then stop at 10001.
             * 
             * HOWEVER, that is incredibly slow!
             * 
             * The better approach, is to still go up, but start at 3, and go up by 2. This will eliminate half of the values we need to check.
             * In addition to that, we only need to check the current number against previous prime numbers, as opposed to every number. 
             * If an even number such as 6 is a multiple of 30, there is no point in even checking it, as 2 is both a multiple of 6, and 30.
             * With that in mind, it would be best to keep a list of prime numbers, and then use that list to keep track of the amount, as well as
             * to use that for checking for the next prime numbers.
             * 
             */

            const int count = 10001;

            List<int> primes = new List<int>();

            //add 2 since we are skipping it, and it is the only even number
            primes.Add(2);

            //start at 3 and go
            for(int i = 3; primes.Count() < count; i += 2)
            {
                if(Helper.IsPrime(i, primes))
                {
                    primes.Add(i);
                }
            }

            return primes[count - 1].ToString();
        }
    }
}
