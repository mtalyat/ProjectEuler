using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem6 : Problem
    {
        protected override uint Number => 6;

        protected override string GetPrompt()
        {
            return "The sum of the squares of the first ten natural numbers is,\n1^2 + 2^2 + ... + 10^2 = 385.\n\n" +
                "The square of the sum of the first ten natural numbers is,\n(1 + 2 + ... + 10)^2 = 55^2 = 3025\n\n" +
                "Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.\n\n" +
                "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";
        }

        protected override string Solve()
        {
            /*
             * First find the sum of squares.
             * 
             * Then find the square of the sums.
             * 
             * This can be done simultaneously in one loop. Square and add for the sum of the squares, and add then square (after the loop) for square of sums.
             * 
             * Then do the math (subtract them).
             * 
             */

            const uint count = 100;
            uint sumOfSquares = 0;
            uint squareOfSums = 0;

            for(uint i = 1; i <= count; i++)
            {
                //do the square and add it
                sumOfSquares += i * i;

                //do the adding now, square after the loop
                squareOfSums += i;
            }

            squareOfSums *= squareOfSums;

            return (squareOfSums - sumOfSquares).ToString();
        }
    }
}