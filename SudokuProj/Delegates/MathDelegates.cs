using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuProj.Model;
using SudokuProj.ViewModels;

namespace SudokuProj.Delegates
{
    public static class MathDelegates
    {
        // Get List of String from Int Array
        public static List<string> GetStringFromIntArray(this int[] array)
        {
            List<string> txt = new List<string>();

            foreach (var item in array)
            {
                if (item <= -1)
                {
                    txt.Add("X");
                }
                else
                {
                    txt.Add(item.ToString());
                }
            }

            return txt;
        }
        // For getting List of String from List of Int Array
        public static List<string> GetStringFromIntArray(this List<int[]> array)
        {
            List<string> txt = new List<string>();

            foreach (var item in array)
            {
                txt.AddRange(item.GetStringFromIntArray());
            }

            return txt;
        }
    }
}
