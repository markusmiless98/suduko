using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.Model
{
    public class SudukoSpace
    {
        private int row;
        public int Row {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        private int column;
        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 9)
                {
                    number = 9;
                    NumberImg = SudokuGUIInfo.gui_info["9"];
                }
                else if (value < 0)
                {
                    number = -1;
                    NumberImg = SudokuGUIInfo.gui_info["bg"];
                }
                else
                {
                    number = value;
                    NumberImg = SudokuGUIInfo.gui_info[value.ToString()];
                }
            }
        }
        private string numbImg;
        public string NumberImg
        {
            get
            {
                return numbImg;
            }
            set
            {
                numbImg = value;
            }
        }
    }
    public class SudokuGUIInfo
    {
        public static Dictionary<string, string> gui_info = new Dictionary<string, string>()
        {
            { "bg", "square_bg_norm.png"},
            { "0", "square_zero.png"},
            { "1", "square_one.png"},
            { "2", "square_two.png"},
            { "3", "square_three.png"},
            { "4", "square_four.png"},
            { "5", "square_five.png"},
            { "6", "square_six.png"},
            { "7", "square_seven.png"},
            { "8", "square_eight.png"},
            { "9", "square_nine.png"},
            { "-1", "square_bg_norm.png" },
        };
    }
}
