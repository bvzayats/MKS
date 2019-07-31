using System;
using System.ComponentModel.DataAnnotations;

namespace Festival.Models
{
    public class BandDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }
        [Required]
        public DateTime PerformanceTime { get; set; }
        public int? Fee { get; set; }
    }
}
