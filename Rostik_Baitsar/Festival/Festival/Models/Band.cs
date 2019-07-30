using System;

namespace Festival.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime PerformanceTime { get; set; }
        public int? Fee { get; set; }
    }
}
