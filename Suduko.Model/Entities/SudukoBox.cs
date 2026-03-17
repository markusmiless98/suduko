using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduko.Model.Entities
{
    public class SudukoBox
    {
        public int Id { get; set; }

        public int? Box1 { get; set; }
        public int? Box2 { get; set; }
        public int? Box3 { get; set; }
        public int? Box4 { get; set; }
        public int? Box5 { get; set; }
        public int? Box6 { get; set; }
        public int? Box7 { get; set; }
        public int? Box8 { get; set; }
        public int? Box9 { get; set; }
    }
}
