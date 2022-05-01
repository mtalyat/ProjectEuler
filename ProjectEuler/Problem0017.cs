using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0017 : Problem
    {
        private static string[] numberNames = new string[]
        {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static string[] tensNumberNames = new string[]
        {
                "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        protected override uint Number => 17;

        protected override string GetPrompt()
        {
            return @"If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of 'and' when writing out numbers is in compliance with British usage.";
        }

        protected override string Solve()
        {
            /*
             * This problem is relatively straightforward. Some arrays are needed for the lookup of the word versions of numbers, otherwise the problem is
             * just determining what to do with each value of the numbers.
             * 
             * This problem took way too long to debug... I misspelled "forty" as "fourty".
             */

            const int count = 1000;

            //now start throwing the numbers into a string
            ulong letterCount = 0;

            for (int i = 1; i <= count; i++)
            {
                letterCount += (ulong)NumberToString(i).Length;
            }

            return letterCount.ToString();
        }

        private string NumberToString(int number)
        {
            StringBuilder sb = new StringBuilder();

            //split up based on string
            int[] digits = (number.ToString().PadLeft(4, '0')).Select(c => int.Parse(c.ToString())).ToArray();

            //if digit is 0, ignore
            int thousands = digits[0];
            int hundreds = digits[1];
            int tens = digits[2];
            int ones = digits[3];
            int combined = tens * 10 + ones;

            if(thousands > 0)
            {
                sb.Append(numberNames[thousands - 1]);
                sb.Append("Thousand");
            }

            if(hundreds > 0)
            {
                sb.Append(numberNames[hundreds - 1]);
                sb.Append("Hundred");
            }

            if((thousands > 0 || hundreds > 0) && (tens > 0 || ones > 0))
            {
                //we need an and, since this website is Bri'ish
                sb.Append("And");
            }

            if(tens > 1)
            {
                //if twenties or higher, follow similar format as above
                sb.Append(tensNumberNames[tens - 2]);
                if(ones > 0)
                {
                    sb.Append(numberNames[ones - 1]);
                }
            } else if (combined > 0)
            {
                //special... in teens or lower
                sb.Append(numberNames[combined - 1]);
            }

            return sb.ToString();
        }
    }
}
