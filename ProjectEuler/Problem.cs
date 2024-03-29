﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectEuler
{
    /// <summary>
    /// The base class for all problems. This is to help keep the code organized and streamlined.
    /// </summary>
    internal abstract class Problem
    {
        private uint GetProblemNumber()
        {
            //get the class name
            string name = GetType().Name;

            //number is last 4 characters
            string number = name.Substring(name.Length - 4, 4);

            uint i;
            if(uint.TryParse(number, out i))
            {
                return i;
            }

            //invalid
            return 0;
        }

        private string GetProblemTitle()
        {
            return $"Problem {GetProblemNumber()}";
        }

        /// <summary>
        /// Gets the prompt for this problem.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetPrompt();

        /// <summary>
        /// Does the calculations to solve the problem, and then writes them to the screen.
        /// </summary>
        /// <returns>A string representing the solution to the problem.</returns>
        protected abstract string Solve();

        /// <summary>
        /// Prints the result to the screen, nicely.
        /// </summary>
        /// <param name="result"></param>
        private void PrintResult(string result)
        {
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Writes the prompt, does the work to solve the equation, and then prints the results with the total elapsed time.
        /// </summary>
        public void DoWork()
        {
            Console.WriteLine($"{GetProblemTitle()}:\n");

            Console.WriteLine($"{GetPrompt()}\n");

            string result;

            Stopwatch watch = Stopwatch.StartNew();

            result = Solve();

            watch.Stop();

            PrintResult(result);

            long completionMilliseconds = watch.ElapsedMilliseconds;
            long completionSeconds = completionMilliseconds / 1000;

            if(completionSeconds > 0)
            {
                Console.WriteLine($"{GetProblemTitle()} completed in {completionSeconds}.{completionMilliseconds % 1000} seconds.");
            } else
            {
                Console.WriteLine($"{GetProblemTitle()} completed in {completionMilliseconds} milliseconds.");
            }
        }
    }
}
