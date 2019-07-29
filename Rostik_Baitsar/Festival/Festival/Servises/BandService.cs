using Festival.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Servises
{
    public class BandService
    {
        private readonly BandContext _context;

        public BandService(BandContext context)
        {
            _context = context;
        }

        public async Task<List<Band>> GetBands()
        {
            return await _context.Bands.ToListAsync();
        }

        public async Task<Band> GetBand(int id)
        {
            var band = await _context.Bands.FindAsync(id);

            return band;
        }
    }
}
