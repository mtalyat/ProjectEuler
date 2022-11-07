using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0024 : Problem
    {
        private const int GOAL = 999999;

        private const int LENGTH = 10;

        protected override string GetPrompt()
        {
            return @"A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?";

            /*
             * For 0 1
             * 
             *  x2
             * 
             *  01      10
             * 
             * For 0 1 2
             * 
             *  x6
             * 
             *  012     021     102     120     201     210
             * 
             * For 0 1 2 3
             * 
             *  x24
             * 
             *  0123    0132    0213    0231    0312    0321    1023    1032    1203    1230    1302    1320    2013    2031    2103    2130    2301    2310    3012    3021    3102    3120    3201    3210
             * 
             * For 0 1 2 3 4 5
             * 
             *  0       1       2       3       4       5
             *  012345  012354  012435  012453  012534  012543
             *  
             *  
             *  031245
             */
        }

        protected override string Solve()
        {
            /*
             * 
             * Brute forcing this would take ages.
             * 
             * To speed up the calculations, manual permutations can be skipped. Using the above examples, it can be seen that for each number of digits, n,
             * the amount of permutations counts as follows:
             * 
             * a_n = a_n-1 * n
             * a_1 = 1
             * 
             * Therefore, to find the millionth permutation, we can use the algorithm to "skip" parts of the computations.
             * 
             * For 10 digits, the above algorithm will result with 3,628,800 permutations for 10 digits.
             * 
             */

            return Permute(GOAL, LENGTH);
        }

        /// <summary>
        /// Completes a full permutation of an array of the given length, until it reaches the goal (nth) permutation.
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string Permute(int goal, int length)
        {
            // number of permutations
            int permutations = goal;
            int permutationIndex = length;
            int temp;

            int[] digits = Enumerable.Range(0, length).ToArray();

            while (permutations > 0 && permutationIndex > 1)
            {
                // find the amount
                temp = PermutationsAlgorithm(permutationIndex - 1);

                // if too high, skip
                if (temp <= permutations)
                {
                    // find amount that fits
                    int permuteCount = permutations / temp;

                    // shift permutations count, skip permutations we don't care about
                    permutations -= temp * permuteCount;

                    // permute
                    QuickPermute(digits, length - permutationIndex, permuteCount);
                }

                // continue to next
                permutationIndex--;
            }

            // return result
            return string.Join("", digits);
        }

        /// <summary>
        /// Gets the number of permutations that will happen in an array of the given n count.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int PermutationsAlgorithm(int n)
        {
            if(n <= 0)
            {
                return 0;
            } else if (n == 1)
            {
                return 1;
            } else
            {
                return n * PermutationsAlgorithm(n - 1);
            }
        }

        /// <summary>
        /// Shifts the given array from start to start + index to the left.
        /// </summary>
        /// <param name="digits"></param>
        /// <param name="start"></param>
        /// <param name="index"></param>
        private void QuickPermute(int[] digits, int start, int index)
        {
            // if index is the same as the staty, do nothing
            if(index == 0)
            {
                return;
            }

            int temp;

            // shift from the start+index to the start
            for (int i = start + index; i > start; i--)
            {
                temp = digits[i - 1];
                digits[i - 1] = digits[i];
                digits[i] = temp;
            }
        }
    }
}
