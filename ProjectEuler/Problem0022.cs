using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0022 : Problem
    {
        protected override uint Number => 22;

        protected override string GetPrompt()
        {
            return @"Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?";
        }

        protected override string Solve()
        {
            /*
             * Steps:
             * 
             * 1) Load text from file
             * 2) Eliminate all double quotes ("), they are uneccesary
             * 3) Split up by commas
             * 4) Sort the names alphabetically
             * 5) Convert the names into their scores, based on their (index + 1) and their letter values (c - 'A' + 1)
             * 6) Sum the values
             * 7) Convert to string to print the result
             */

            //timing may be off, we have to parse the file here
            return Resources.Resources.names
                .Replace("\"", "")
                .Split(',')
                .OrderBy(s => s)
                .Select((s, i) => (long)((i + 1) * s.Select(c => int.Parse((c - 'A' + 1).ToString())).Sum()))
                .Sum()
                .ToString();
        }
    }
}
