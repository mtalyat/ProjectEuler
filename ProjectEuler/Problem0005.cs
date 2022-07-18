using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0005 : Problem
    {
        protected override string GetPrompt()
        {
            return "2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.\n\n" +
                "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";
        }

        protected override string Solve()
        {
            /*
             * For this problem, all you gotta do is keep checking numbers until you find one that all are divisible by each number from 2 to 20.
             * We ignore 1 since every number is divisible by 1.
             * 
             */

            const int count = 20;

            int i, j;
            bool found;
            for (i = count; i < int.MaxValue; i++)
            {
                //assume we find it
                found = true;

                for(j = 2; j <= count; j++)
                {
                    //found an instance where it is not divisible
                    if(i % j != 0)
                    {
                        found = false;
                        break;
                    }
                }

                if (found) break;
            }

            return i.ToString();
        }
    }
}
