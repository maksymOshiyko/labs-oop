using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel
{
    public static class Converter26Sys
    {
        private static int _numberOfSymbols = 26;
        private static int _asciiIndexOfA = 65;
        private static int _asciiIndexOfZ = 90;
        private static int _asciiIndexOf0 = 48;
        private static int _asciiIndexOf9 = 57;

        public static string To26Sys(int num)
        {
            int k = 0;
            int size = 20;
            int[] arr = new int[size];

            while (num > _numberOfSymbols - 1)
            {
                arr[k] = num / _numberOfSymbols - 1;
                k++;
                num = num % _numberOfSymbols;
            }

            arr[k] = num;

            string result = "";
            for (int j = 0; j <= k; j++)
            {
                result += ((char)('A' + arr[j])).ToString();
            }

            return result;
        }

        public static Index From26Sys(string expression)
        {
            Index index = new Index();
            index.column = 0;
            index.row = 0;

            for (int j = 0; j < expression.Length; j++)
            {
                if (expression[j] >= _asciiIndexOfA && expression[j] <= _asciiIndexOfZ)
                {
                    index.column *= _numberOfSymbols;
                    index.column += expression[j] - 64;
                }
                else if (expression[j] >= _asciiIndexOf0 && expression[j] <= _asciiIndexOf9)
                {
                    index.row = int.Parse(expression.Substring(j, expression.Length - j));
                    break;
                }
            }

            index.column--;
            return index;
        }
    }
}
