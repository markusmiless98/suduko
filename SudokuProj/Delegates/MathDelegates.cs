using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuProj.Model;

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
                if (item == null || item <= -1)
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
        public static List<SudukoSpace> GetPictureFromIntArray(this List<int[]> array)
        {
            List<SudukoSpace> spaces = new List<SudukoSpace>();

            int row = 0;
            int col = 0;

            foreach (var item in array)
            {
                foreach (var ints in item)
                {
                    SudukoSpace space = new SudukoSpace();
                    space.Column = col;
                    space.Row = row;
                    space.Number = ints;
                    col++;
                    spaces.Add(space);
                }
                row++;
                col = 0;
            }

            return spaces;
        }

    }
}
