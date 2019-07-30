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
        public DateTime PerformanceTime { get; set; }

        public static Band ConvertToEntity(BandDTO bandDTO)
        {
            Band band = new Band()
            {
                Id              = bandDTO.Id,
                Name            = bandDTO.Name,
                PerformanceTime = bandDTO.PerformanceTime
            };

            return band;
        }
    }
}
