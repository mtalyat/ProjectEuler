using System;
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
        /// <summary>
        /// Gets the number of this problem.
        /// </summary>
        /// <returns></returns>
        protected abstract uint GetProblemNumber();

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
        protected abstract void Solve();

        /// <summary>
        /// Prints the result to the screen, nicely.
        /// </summary>
        /// <param name="result"></param>
        protected void PrintResult(string result)
        {
            Console.WriteLine($"Result: {result}");
        }

        protected void PrintResult(int result) => PrintResult(result.ToString());
        protected void PrintResult(uint result) => PrintResult(result.ToString());
        protected void PrintResult(long result) => PrintResult(result.ToString());
        protected void PrintResult(ulong result) => PrintResult(result.ToString());
        protected void PrintResult(double result) => PrintResult(result.ToString());
        protected void PrintResult(float result) => PrintResult(result.ToString());

        /// <summary>
        /// Writes the prompt, does the work to solve the equation, and then prints the results with the total elapsed time.
        /// </summary>
        public void DoWork()
        {
            Console.WriteLine($"{GetProblemTitle()}:\n");

            Console.WriteLine($"{GetPrompt()}\n");

            Stopwatch watch = Stopwatch.StartNew();

            Solve();

            watch.Stop();

            long completionMilliseconds = watch.ElapsedMilliseconds;
            long completionSeconds = completionMilliseconds / 1000;

            if(completionSeconds > 0)
            {
                Console.WriteLine($"{GetProblemTitle()} completed in {completionSeconds} seconds.");
            } else
            {
                Console.WriteLine($"{GetProblemTitle()} completed in {completionMilliseconds} milliseconds.");
            }
        }
    }
}
