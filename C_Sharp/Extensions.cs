using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal static class Extensions
    {
        /// <summary>
        /// Turns the array into a stringified version of the array. Ex. -> [1, 4, 7, 3, 2, 7]
        /// </summary>
        /// <param name="array"></param>
        /// <param name="open"></param>
        /// <param name="separator"></param>
        /// <param name="close"></param>
        /// <returns></returns>
        public static string ToStringifiedArray(this Array array, string open = "[", string separator = ", ", string close = "]")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(open);

            object? obj;

            for(int i = 0; i < array.Length; i++)
            {
                //add string version of item
                obj = array.GetValue(i);

                if(obj == null)
                {
                    continue;
                }

                sb.Append(obj.ToString());

                if(i < array.Length - 1)
                {
                    //if not at the end, add the ", " between values
                    sb.Append(separator);
                }
            }

            //add the closing bracket, then return
            sb.Append(close);

            return sb.ToString();
        }

        /// <summary>
        /// Turns the array into a 2D stringified version of the array. Ex. ->
        /// [
        ///     [2, 6, 3]
        ///     [6, 8, 1]
        /// ]
        /// </summary>
        /// <param name="array"></param>
        /// <param name="width"></param>
        /// <param name="padding"></param>
        /// <param name="open"></param>
        /// <param name="separator"></param>
        /// <param name="close"></param>
        /// <returns></returns>
        public static string To2DStringifiedArray(this Array array, int width, int padding = 0, string open = "[", string separator = ", ", string close = "]")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(open);
            sb.Append("\n");

            //print each of the lines
            for (int i = 0; i < array.Length; i++)
            {
                if(i % width == 0)
                {
                    //if at the beginning of a row, tab it and print the open bracket
                    sb.Append('\t');
                    sb.Append(open);
                }
                
                //add the value itself
                sb.Append((array.GetValue(i)?.ToString() ?? string.Empty).PadLeft(padding));

                if(i % width < width - 1)
                {
                    //if not at the end of this row, add a separator
                    sb.Append(separator);
                } else
                {
                    //if at the end, print the close bracket and go to the next line
                    sb.Append(close);
                    sb.Append('\n');
                }
            }

            sb.Append(close);

            return sb.ToString();
        }
    }
}
