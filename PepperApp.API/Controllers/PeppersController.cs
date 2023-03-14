using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PepperApp.Data;
using PepperApp.Entities;

namespace PepperApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeppersController : ControllerBase
    {
        private readonly PepperContext _context;

        public PeppersController(PepperContext context)
        {
            _context = context;
        }

        // GET: api/Peppers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pepper>>> GetPeppers()
        {
          if (_context.Peppers == null)
          {
              return NotFound();
          }
            return await _context.Peppers.ToListAsync();
        }

        // GET: api/Peppers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pepper>> GetPepper(Guid id)
        {
          if (_context.Peppers == null)
          {
              return NotFound();
          }
            var pepper = await _context.Peppers.FindAsync(id);

            if (pepper == null)
            {
                return NotFound();
            }

            return pepper;
        }

        // PUT: api/Peppers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPepper(Guid id, Pepper pepper)
        {
            if (id != pepper.PepperId)
            {
                return BadRequest();
            }

            _context.Entry(pepper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PepperExists(id))
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

        // POST: api/Peppers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pepper>> PostPepper(Pepper pepper)
        {
          if (_context.Peppers == null)
          {
              return Problem("Entity set 'PepperContext.Peppers'  is null.");
          }
            _context.Peppers.Add(pepper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPepper", new { id = pepper.PepperId }, pepper);
        }

        // DELETE: api/Peppers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePepper(Guid id)
        {
            if (_context.Peppers == null)
            {
                return NotFound();
            }
            var pepper = await _context.Peppers.FindAsync(id);
            if (pepper == null)
            {
                return NotFound();
            }

            _context.Peppers.Remove(pepper);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PepperExists(Guid id)
        {
            return (_context.Peppers?.Any(e => e.PepperId == id)).GetValueOrDefault();
        }
    }
}
