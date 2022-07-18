using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0015 : Problem
    {
        protected override string GetPrompt()
        {
            return @"Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

How many such routes are there through a 20×20 grid?";
        }

        protected override string Solve()
        {
            /*
             * This problem is similar to the last problem, in regards to using a dictionary. Once you hit a certain point in the grid, the amount of paths
             * you can take from that point is the same every time.
             * 
             * However, in this case, since it is a grid, we don't need a dictionary. We can use a 2D array (or a "2D" array, in this case). By starting from the bottom,
             * we can mathematically calculate each possible number of paths from the end, and then just do some addition to find the number for each other place, ending
             * with the start (which will then have the total of all possible paths).
             */

            //add one to size, since the size of the grid in the example counts the spaces. We count the intersections.
            const int size = 21;

            ulong[] grid = new ulong[size * size];

            ulong count;

            bool v, h;

            for(int row = size - 1; row >= 0; row--)
            {
                v = row < size - 1;

                for(int col = size - 1; col >= 0; col--)
                {
                    h = col < size - 1;

                    //amount of possible paths = amount of possible paths of the grid below + amount of possible paths of the grid to the right
                    count = 0;
                    
                    //adding 1 to account for the path taken through this position in the grid

                    if(h && v)//if can go both paths, add
                    {
                        count += grid[(row + 1) * size + col] + grid[row * size + col + 1];
                    } else
                    {
                        //only one path otherwise
                        count = 1;
                    }

                    //set data in this position
                    grid[row * size + col] = count;
                }
            }

            //the answer is at 0, 0
            return grid[0].ToString();
        }
    }
}
