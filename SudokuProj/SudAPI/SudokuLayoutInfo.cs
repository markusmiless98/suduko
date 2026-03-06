using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuProj.Model;

namespace SudokuProj.SudAPI
{
    internal enum DifficulityLevel
    {
        Easy,
        Medium,
        Hard
    }
    // To instruct the API
    internal class SudokuLayoutInfo
    {
        private DifficulityLevel difficulity = DifficulityLevel.Easy;
        // Default values 3*3
        private int width = 3;
        private int height = 3;

        public DifficulityLevel _Difficulity
        {
            get { return difficulity; }
            set
            {
                difficulity = value;
            }
        }
        public int _Width
        {
            get { return width; }
            set
            {
                if (value >= 1)
                {
                    width = value;
                }
            }
        }
        public int _Height
        {
            get { return height; }
            set
            {
                if (value >= 1)
                {
                    height = value;
                }
            }
        }
    }
}
