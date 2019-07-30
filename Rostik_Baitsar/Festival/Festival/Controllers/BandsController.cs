using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Festival.Models;
using Festival.Servises;
using Microsoft.EntityFrameworkCore;

namespace Festival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IBandService _bandService;
        public BandsController(IBandService bandService)
        {
            _bandService = bandService;
        }

        // GET: api/Bands
        [HttpGet]
        public async Task<IActionResult> GetBands()
        {
            var band = await _bandService.GetBands();
            return Ok(band);
        }

        // GET: api/Bands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBand(int id)
        {
            var band = await _bandService.GetBand(id);
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
            var _band = await _bandService.PutBand(id, band);

            if (_band == null)
                return BadRequest();

            return Ok(band);
        }

        // POST: api/Bands
        [HttpPost]
        public async Task<IActionResult> PostBand(Band band)
        {
            return Ok(await _bandService.PostBand(band));
        }

        // DELETE: api/Bands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            var band = await _bandService.DeleteBand(id);

            if (band == null)
                return NotFound();

            return Ok(band);
        }
    }
}
