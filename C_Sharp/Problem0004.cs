using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0004 : Problem
    {
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
             * That is pretty much what worked. Only thing I added to my initial thought was checking for when the value cannot be a larger
             * number, in which case the algorithm just stops checking, as it is unecessary.
             * 
             */

            int product;
            int largest = 0;

            for(int i = 999; i >= 1; i--)
            {
                //if it is impossible to get a higher palindrome, stop
                if (i * 999 <= largest) break;

                for(int j = 999; j >= 1; j--)
                {
                    product = i * j;

                    //if not even high enough, stop. Values will only get lower
                    if(product < largest) break;

                    //check if palindrome. If it is, set it and be done
                    if(IsPalindrome(product))
                    {
                        largest = product;
                        break;
                    }
                }
            }

            return largest.ToString();
        }

        private bool IsPalindrome(int number)
        {
            //convert to string to check for a palindrome
            string n = number.ToString();

            //start at the ends and move inwards
            for (int i = 0; i < n.Length / 2; i++)
            {
                if(n[i] != n[n.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
