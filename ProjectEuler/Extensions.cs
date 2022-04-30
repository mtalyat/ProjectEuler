using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal static class Extensions
    {
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
    }
}
