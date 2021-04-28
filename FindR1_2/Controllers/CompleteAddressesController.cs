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
    public class CompleteAddressesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompleteAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompleteAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompleteAddress>>> GetCompleteAddresses()
        {
            return await _context.CompleteAddresses.ToListAsync();
        }

        // GET: api/CompleteAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompleteAddress>> GetCompleteAddress(int id)
        {
            var completeAddress = await _context.CompleteAddresses.FindAsync(id);

            if (completeAddress == null)
            {
                return NotFound();
            }

            return completeAddress;
        }

        // PUT: api/CompleteAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompleteAddress(int id, CompleteAddress completeAddress)
        {
            if (id != completeAddress.CompleteAddress_Id)
            {
                return BadRequest();
            }

            _context.Entry(completeAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompleteAddressExists(id))
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

        // POST: api/CompleteAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompleteAddress>> PostCompleteAddress(CompleteAddress completeAddress)
        {
            _context.CompleteAddresses.Add(completeAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompleteAddress", new { id = completeAddress.CompleteAddress_Id }, completeAddress);
        }

        // DELETE: api/CompleteAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompleteAddress(int id)
        {
            var completeAddress = await _context.CompleteAddresses.FindAsync(id);
            if (completeAddress == null)
            {
                return NotFound();
            }

            _context.CompleteAddresses.Remove(completeAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompleteAddressExists(int id)
        {
            return _context.CompleteAddresses.Any(e => e.CompleteAddress_Id == id);
        }
    }
}
