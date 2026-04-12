using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0025 : Problem
    {
        private const int GOAL = 1000;

        protected override string GetPrompt()
        {
            return @"The Fibonacci sequence is defined by the recurrence relation:

Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
Hence the first 12 terms will be:

F1 = 1
F2 = 1
F3 = 2
F4 = 3
F5 = 5
F6 = 8
F7 = 13
F8 = 21
F9 = 34
F10 = 55
F11 = 89
F12 = 144
The 12th term, F12, is the first term to contain three digits.

What is the index of the first term in the Fibonacci sequence to contain 1000 digits?";
        }

        protected override string Solve()
        {
            // brute force solution
            BigInteger left = 0;
            BigInteger right = 1;

            BigInteger value;

            // start would be -1
            // adding 2 to account for F1 and F2
            int index = 1;

            // complete fibonacci until value digits is greater than 1000
            do
            {
                value = left + right;

                left = right;
                right = value;

                index++;
            } while (value.ToString().Length < GOAL);

            // return the index
            return index.ToString();
        }
    }
}
