using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SudokuProj.Delegates;

namespace SudokuProj.Model
{
    public class SudukoLayout
    {
        private List<int[]> _puzzle;
        [JsonPropertyName("puzzle")]
        public List<int[]> Puzzle
        {
            get { return _puzzle; }
            set
            {
                _puzzle = value;
                PuzzleImages = Puzzle.GetPictureFromIntArray();
            }
        }
        public List<string> PuzzleImages { get; set; }
        public List<int[]> _solution;
        [JsonPropertyName("solution")]
        public List<int[]> Solution {
            get { return _solution; }
            set
            {
                _solution = value;
                SolutionImages = Solution.GetPictureFromIntArray();
            }
        }
        public List<string> SolutionImages { get; set; }

    }
}
