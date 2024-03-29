﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0008 : Problem
    {
        protected override string GetPrompt()
        {
            return "The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.\n\n" +
                "\t73167176531330624919225119674426574742355349194934\n" +
                "\t96983520312774506326239578318016984801869478851843\n" +
                "\t85861560789112949495459501737958331952853208805511\n" +
                "\t12540698747158523863050715693290963295227443043557\n" +
                "\t66896648950445244523161731856403098711121722383113\n" +
                "\t62229893423380308135336276614282806444486645238749\n" +
                "\t30358907296290491560440772390713810515859307960866\n" +
                "\t70172427121883998797908792274921901699720888093776\n" +
                "\t65727333001053367881220235421809751254540594752243\n" +
                "\t52584907711670556013604839586446706324415722155397\n" +
                "\t53697817977846174064955149290862569321978468622482\n" +
                "\t83972241375657056057490261407972968652414535100474\n" +
                "\t82166370484403199890008895243450658541227588666881\n" +
                "\t16427171479924442928230863465674813919123162824586\n" +
                "\t17866458359124566529476545682848912883142607690042\n" +
                "\t24219022671055626321111109370544217506941658960408\n" +
                "\t07198403850962455444362981230987879927244284909188\n" +
                "\t84580156166097919133875499200524063689912560717606\n" +
                "\t05886116467109405077541002256983155200055935729725\n" +
                "\t71636269561882670428252483600823257530420752963450\n\n" +
                "Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?";
        }

        protected override string Solve()
        {
            /*
             * The most efficient way to go through this would almost be to "snake" through the array of digits.
             * Meaning, by using an index and a length (count), we will go through each set of adjacent digits by incrementing
             * by one for each iteration. As we increment, we will divide by the digit at index - 1, and then multiply by
             * the newest digit at index + count.
             * 
             * The reason for doing this is to avoid having to re-multiply all of the digits every time.
             * 
             * However... after evaluating the string, there are zeroes. This would not work. 
             * Instead, the values must be re-evaluated for each set.
             * 
             * Once we find a new highest product, we can record the index the product was found. At the end of the iteration,
             * the highest index will be saved, in which the digits can be found.
             */

            const int count = 13;

            //string of digits
            string digitsStr = 
                "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            //turn into an array of digits for easy processing
            long[] digits = digitsStr.Select(i => long.Parse(i.ToString())).ToArray();

            long product = 0;
            long maxProduct = product;

            //go through array, check each set
            for (int i = 0; i + count <= digits.Length; i++)
            {
                product = 1;
                for (int j = 0; j < count; j++)
                {
                    product *= digits[i + j];
                }

                maxProduct = Math.Max(maxProduct, product);
            }

            return maxProduct.ToString();
        }
    }
}
