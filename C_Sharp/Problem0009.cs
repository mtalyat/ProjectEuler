using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0009 : Problem
    {
        protected override string GetPrompt()
        {
            return "A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,\n\n" +
                "\t\t\t\t\t\t\ta^2 + b^2 = c^2\n\n" +
                "For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.\n\n" +
                "There exists exactly one Pythagorean triplet for which a + b + c = 1000.\n" +
                "Find the product abc.";
        }

        protected override string Solve()
        {
            /*
             * This problem requires some mathematical thinking.
             * 
             * a < b < c, AND a^2 + b^2 = c^2, AND a + b + c = 1000 AND a * b * c = ?
             * 
             * Where ? is the answer.
             * 
             * I tried to do this mathematically, but to no avail.
             * 
             * Programatically, the way I thought to do this was to use a nested for loop.
             * The for loop will ensure a < b < c, and it will also cut down on calculation costs
             * (as opposed to having to check a from 1 to 1000, b from 1 to 1000, and so on).
             * 
             * Then, inside the inner for loop, the other conditions are checked, and if they match, that is the solution.
             * 
             */

            const int count = 1000;

            //by doing the for loops as such, it is guaranteed that a < b < c
            for (int a = 1; a < count; a++)
            {
                for (int b = a + 1; b < count; b++)
                {
                    for (int c = b + 1; c < count; c++)
                    {
                        //now that we have a, b and c, check if it meets the other conditions
                        if(a + b + c == 1000 && (a * a) + (b * b) == (c * c))
                        {
                            //it was found
                            return (a * b * c).ToString();
                        }                        
                    }
                }
            }

            return "Not found";
        }
    }
}
