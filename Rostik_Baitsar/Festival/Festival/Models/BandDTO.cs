using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Models
{
    public class BandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime PerformanceTime { get; set; }
        public int? Fee { get; set; }
    }
}
