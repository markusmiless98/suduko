using System.Text.Json.Serialization;

namespace Suduko.Model.Entities
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
            }
        }
        public List<int[]> _solution;
        [JsonPropertyName("solution")]
        public List<int[]> Solution
        {
            get { return _solution; }
            set
            {
                _solution = value;
            }
        }
    }
}
