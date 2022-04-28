using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem4 : Problem
    {
        protected override uint Number => 4;

        protected override string GetPrompt()
        {
            return "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.\n\n" +
                "Find the largest palindrome made from the product of two 3 - digit numbers.";
        }

        protected override string Solve()
        {
            /*
             * For this problem, my first instinct is to start at i = 999 and j = 999, multiply, check, and then decrement j. 
             * Once a palindrome is hit, set j back to i - , decrement i, and repeat those steps... something like that.
             * 
             * After some reconsideration, here is what I came up with:
             * 
             */



            return "";
        }
    }
}
