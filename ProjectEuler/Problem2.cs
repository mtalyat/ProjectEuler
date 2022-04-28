﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem2 : Problem
    {
        protected override uint GetProblemNumber()
        {
            return 2;
        }

        protected override string GetPrompt()
        {
            return "Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:\n\n" +
                "1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\n\n" +
                "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";
        }

        protected override void Solve()
        {
            const int count = 4000000;

            int sum = 0;

            for (int i = 0, j = 1, k = 2; j < count && k < count; i++)
            {
                //add the higher one to the sum, if it is even
                //increment every other, so j and k are always the current or last number
                if(i % 2 == 0)
                {
                    if(k % 2 == 0)
                    {
                        sum += k;
                    }
                    j += k;
                } else
                {
                    if(j % 2 == 0)
                    {
                        sum += j;
                    }
                    k += j;
                }
            }

            PrintResult(sum);
        }
    }
}