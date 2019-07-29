using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Festival.Models;

namespace Festival.Controllers
{
    [Route("api")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly BandContext _context;

        public BandsController(BandContext context)
        {
            _context = context;
        }

        // GET: api/Bands
        [HttpGet]
        public async Task<IActionResult> GetBands()
        {
            return Ok(await _context.Bands.ToListAsync());
        }

        // GET: api/Bands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBand(int id)
        {
            var band = await _context.Bands.FindAsync(id);

            if (band == null)
            {
                return NotFound();
            }

            return Ok(band);
        }

        // PUT: api/Bands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBand(int id, Band band)
        {
            return Ok();
        }

        // POST: api/Bands
        [HttpPost]
        public async Task<ActionResult<Band>> PostBand(Band band)
        {
            return Ok();
        }

        // DELETE: api/Bands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            return Ok();
        }

        private bool BandExists(int id)
        {
            return _context.Bands.Any(e => e.Id == id);
        }
    }
}
