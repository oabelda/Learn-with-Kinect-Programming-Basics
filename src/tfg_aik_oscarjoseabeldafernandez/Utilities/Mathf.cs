using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Utilities
{
    public static class Mathf
    {
        /// <summary>
        /// Limits a value between two params
        /// </summary>
        /// <param name="number">The value you want to limit</param>
        /// <param name="min">The smallest dimension</param>
        /// <param name="max">The biggest dimension</param>
        /// <returns>Limited value</returns>
        public static double Clamp(double number, double min, double max)
        {
            if (number < min)
            {
                return min;
            }
            else if (number > max)
            {
                return max;
            }
            else
            {
                return number;
            }
        }
        /// <summary>
        /// Counts how many '1's a number would have if it is converted in a binary form
        /// </summary>
        /// <param name="number">A decimal integer number</param>
        /// <returns>Integer number of '1's</returns>
        public static int NumberOfOnesAsBit(long number)
        {
            int returns = 0;
            while (number != 0)
            {
                if (number % 2 == 1) returns++;
                number = number / 2;
            }
            return returns;
        }
        /// <summary>
        /// Transforms a integer number in a string of its binary equivalent
        /// </summary>
        /// <param name="number">A decimal integer number</param>
        /// <returns>Strings of '0's and '1's</returns>
        public static string NumberAsBinaryString(long number)
        {
            string s = "";
            while (number != 0 && number != 1)
            {
                s = (number % 2) + s;
                number = number / 2;
            }
            return (number + s);
        }
        /// <summary>
        /// Function to calculate the number of Figures in a number
        /// </summary>
        /// <param name="number">A decimal integer number</param>
        /// <returns>Integer number of figures</returns>
        public static int NumberOfFigures(long number)
        {
            if (number == 0) return 1;
            int returns = 0;
            while (number != 0)
            {
                returns++;
                number = number / 10;
            }
            return returns;
        }
    }
}
