using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0018 : Problem
    {
        protected override string GetPrompt()
        {
            return @"By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

   3
  7 4
 2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

                     75
                    95 64
                  17 47 82
                 18 35 87 10
               20 04 82 47 65
              19 01 23 75 03 34
            88 02 77 73 07 63 67
           99 65 04 28 06 16 70 92
         41 41 26 56 83 40 80 70 33
        41 48 72 33 47 32 37 16 94 29
      53 71 44 65 25 43 91 52 97 51 14
     70 11 33 28 77 73 17 78 39 68 17 57
   91 71 52 38 17 14 91 43 58 50 27 29 48
  63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)";
        }

        protected override string Solve()
        {
            /*
             * This problem does involve some thinking. As stated by the note, I could naively brute force the triangle and check every route (presumably recursively), 
             * however that would take forever. My second thought is to try something similar to Problem 15, where I used a grid to keep track of the values.
             * In this situation, I would like to start at the bottom, and move the way up the tree. As the algorithm works its way up, it will keep track of which path
             * has the higher total value, then ignore the other. Then as it reaches the top, it would pick the side (path) with the highest total value.
             * 
             * An example of the visualization of this problem using the example triangle:
             * 
             *     3
             *    / 
             *    7 4
             *     \ \
             *   2 4 6
             *  /   \/
             *  8 5 9 3
             *  
             *  Hopefully this makes sense. For 2, for instance, it would have to pick between 8 and 5. 8 is higher, so it selects that.
             *  The lower 4 selects between 5 and 9, and selects 9, and so on.
             *  For 7, however, it has to select between the totals below it, not just the raw values. 7 is picking between 10 (2 + 8) and 13 (4 + 9).
             */

            string treeStr = @"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            //using a jagged array, so each row of the tree can be a different size
            int[][] tree = treeStr.Split('\n').Select(r => r.Split(' ').Select(n => int.Parse(n.ToString())).ToArray()).ToArray();

            int[] row;
            int[] below;
            int left;
            int right;

            for(int i = tree.Length - 2; i >= 0; i--)
            {
                row = tree[i];
                below = tree[i + 1];

                //go through this row
                for (int j = 0; j < row.Length; j++)
                {
                    //get the children
                    left = below[j];
                    right = below[j + 1];

                    //set to value, which is the current value + the max of the lower row
                    row[j] += Math.Max(left, right);
                }
            }

            //the answer is at the top
            return tree[0][0].ToString();
        }
    }
}
