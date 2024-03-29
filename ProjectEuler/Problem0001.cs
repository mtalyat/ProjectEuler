﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0001 : Problem
    {
        protected override string GetPrompt()
        {
            return "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n\n" +
                "Find the sum of all the multiples of 3 or 5 below 1000.";
        }

        protected override string Solve()
        {
            /*
             * In this problem, the best option will be to use 1 thread to solve each side of the problem.
             * Since 3 and 5 are separate, we can do the work at the same time.
             * Then after both threads are done, just combine the values from each of them.
             */

            const int count = 1000;

            int threes = 0;
            int fives = 0;

            for (int i = 0; i < count; i += 3)
            {
                //only don't add if the 5 will catch it, since it is specifically 3 OR 5, not 3 AND 5
                if (i % 5 != 0)
                {
                    threes += i;
                }
            }

            for (int i = 0; i < count; i += 5)
            {
                fives += i;
            }

            //now add together and print
            int result = threes + fives;

            return result.ToString();
        }
    }
}
