using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal static class Helper
    {
        /// <summary>
        /// Checks if number is evenly divisible by any of the integers in primes.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="primes"></param>
        /// <returns>True if all values are not evenly divisible, otherwise false.</returns>
        public static bool IsPrime(int number, List<int> primes)
        {
            //if the number is divisible by one of the primes, stop
            foreach (int prime in primes)
            {
                if (number % prime == 0)
                {
                    //not prime, it is evenly divisible
                    return false;
                }
            }

            return true;
        }
    }
}
