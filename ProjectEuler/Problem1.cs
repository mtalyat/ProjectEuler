using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem1 : Problem
    {
        protected override uint GetProblemNumber()
        {
            return 1;
        }

        protected override string GetPrompt()
        {
            return "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n\n" +
                "Find the sum of all the multiples of 3 or 5 below 1000.";
        }

        protected override void Solve()
        {
            /*
             * In this problem, the best option will be to use 1 thread to solve each side of the problem.
             * Since 3 and 5 are separate, we can do the work at the same time.
             * Then after both threads are done, just combine the values from each of them.
             */

            const int count = 1000;

            int threes = 0;
            int fives = 0;

            Task threeTask = Task.Run(() =>
            {
                for (int i = 0; i < count; i += 3)
                {
                    //only don't add if the 5 will catch it, since it is specifically 3 OR 5, not 3 AND 5
                    if (i % 5 != 0)
                    {
                        threes += i;
                    }
                }
            });

            Task fiveTask = Task.Run(() =>
            {
                for (int i = 0; i < count; i += 5)
                {
                    fives += i;
                }
            });

            //now wait for threads to finish their work
            Task.WaitAll(threeTask, fiveTask);

            //now add together and print
            int result = threes + fives;

            PrintResult(result.ToString());
        }
    }
}
