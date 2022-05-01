using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0014 : Problem
    {
        protected override uint Number => 14;

        protected override string GetPrompt()
        {
            return @"The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.";
        }

        protected override string Solve()
        {
            /*
             * My first thought here was to go from 1 to 999,999 and check each sequence. However, this would be very slow, as there is one thing: patterns.
             * Once a number gets reduced to, say, 16, it will follow the same pattern. With this in mind, I can use a (sorted) dictionary to store the number (key),
             * with the length of the sequence (value).
             * 
             * Then, once a sequence hits a certain number, it can be found in the dictionary.
             */

            const uint count = 999999;

            SortedDictionary<uint, uint> dict = new SortedDictionary<uint, uint>();

            uint maxNumber = 1;
            uint max = 0;
            uint v;

            for (uint i = 1; i <= count; i++)
            {
                v = CollatzSequence(i, 0, dict);

                if(v > max)
                {
                    max = v;
                    maxNumber = i;
                }
            }

            return maxNumber.ToString();
        }

        private uint CollatzSequence(uint number, uint value, SortedDictionary<uint, uint> dict)
        {
            uint v;

            if(dict.TryGetValue(number, out v))
            {
                return v + value;
            } else
            {
                uint count;

                //algorithm stuff
                if(number == 1)
                {
                    count = value + 1;
                } else if(number % 2 == 0)
                {
                    count = CollatzSequence(number / 2, 0, dict) + 1;
                } else
                {
                    count = CollatzSequence(number * 3 + 1, 0, dict) + 1;
                }

                //add to dictionary
                dict.Add(number, count);

                return count;
            }
        }
    }
}
