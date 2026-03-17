namespace Suduko.Model.Entities
{
    public class SudukoLayout
    {
        public int Id { get; set; }

        public ICollection<SudukoBox> ULBox { get; set; }
        public ICollection<SudukoBox> UMBox { get; set; }
        public ICollection<SudukoBox> URBox { get; set; }
        public ICollection<SudukoBox> MLBox { get; set; }
        public ICollection<SudukoBox> MMBox { get; set; }
        public ICollection<SudukoBox> MRBox { get; set; }

        public ICollection<SudukoBox> LLBox { get; set; }
        public ICollection<SudukoBox> LMBox { get; set; }
        public ICollection<SudukoBox> LRBox { get; set; }
    }
}
