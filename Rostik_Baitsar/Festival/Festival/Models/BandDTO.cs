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

        public static Band ConvertToEntity(BandDTO bandDTO)
        {
            Band band = new Band()
            {
                Id              = bandDTO.Id,
                Name            = bandDTO.Name,
                Nationality     = bandDTO.Nationality,
                PerformanceTime = bandDTO.PerformanceTime,
                Fee             = bandDTO.Fee
            };

            return band;
        }
    }
}
