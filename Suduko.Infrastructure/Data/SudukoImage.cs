using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko.Infrastructure.Data
{
    public class SudukoImage
    {
        public static Dictionary<string, string> gui_info = new Dictionary<string, string>()
        {
            { "bg", "square_bg_norm.png"},
            { "[0]", "square_zero.png"},
            { "[1]", "square_one.png"},
            { "[2]", "square_two.png"},
            { "[3]", "square_three.png"},
            { "[4]", "square_four.png"},
            { "[5]", "square_five.png"},
            { "[6]", "square_six.png"},
            { "[7]", "square_seven.png"},
            { "[8]", "square_eight.png"},
            { "[9]", "square_nine.png"},
            { "[-1]", "square_bg_norm.png" },
            { "[ ]", "square_bg_norm.png" },
        };
    }
}
