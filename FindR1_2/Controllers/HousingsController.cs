using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindR1_2.Data;
using FindR1_2.Models;

namespace FindR1_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HousingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Housings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Housing>>> GetHousings()
        {
            return await _context.Housings.ToListAsync();
        }

        // GET: api/Housings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Housing>> GetHousing(int id)
        {
            var housing = await _context.Housings.FindAsync(id);

            if (housing == null)
            {
                return NotFound();
            }

            return housing;
        }

        // PUT: api/Housings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousing(int id, Housing housing)
        {
            if (id != housing.Housing_Id)
            {
                return BadRequest();
            }

            _context.Entry(housing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Housings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Housing>> PostHousing(Housing housing)
        {
            _context.Housings.Add(housing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHousing", new { id = housing.Housing_Id }, housing);
        }

        // DELETE: api/Housings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousing(int id)
        {
            var housing = await _context.Housings.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }

            _context.Housings.Remove(housing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HousingExists(int id)
        {
            return _context.Housings.Any(e => e.Housing_Id == id);
        }
    }
}
