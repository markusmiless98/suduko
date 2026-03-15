using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuProj.Model;
using SudokuProj.ViewModels;

namespace SudokuProj.Delegates
{
    public static class SudukoDelegate
    {
        public static int GetNumOfSud(this double x)
        {
            x += 80;
            return (int)x / 80 - 1;
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
        public static SudokuPageViewModel GetSudukoPageViewFromBinding(this object obj)
        {
            try
            {
                return obj as SudokuPageViewModel;
            }
            catch
            {
                // Idk
                return null;
            }
        }
        public static SudukoLayout GetSudukoFromBinding(this object obj)
        {
            if (obj.GetSudukoPageViewFromBinding() != null)
            {
                return obj.GetSudukoPageViewFromBinding().Suduko;
            }
            return null;
        }
    }
}
