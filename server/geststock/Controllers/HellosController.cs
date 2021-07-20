using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using geststock.Controllers.Models;
using geststock.Models;

namespace geststock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HellosController : ControllerBase
    {
        private readonly GeststockContext _context;

        public HellosController(GeststockContext context)
        {
            _context = context;
        }

        // GET: api/Hellos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hellos>>> GetHellos()
        {
            return await _context.Hellos.ToListAsync();
        }

        // GET: api/Hellos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hellos>> GetHellos(int? id)
        {
            var hellos = await _context.Hellos.FindAsync(id);

            if (hellos == null)
            {
                return NotFound();
            }

            return hellos;
        }

        // PUT: api/Hellos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHellos(int? id, Hellos hellos)
        {
            if (id != hellos.Id)
            {
                return BadRequest();
            }

            _context.Entry(hellos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HellosExists(id))
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

        // POST: api/Hellos
        [HttpPost]
        public async Task<ActionResult<Hellos>> PostHellos(Hellos hellos)
        {
            _context.Hellos.Add(hellos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHellos", new { id = hellos.Id }, hellos);
        }

        // DELETE: api/Hellos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hellos>> DeleteHellos(int? id)
        {
            var hellos = await _context.Hellos.FindAsync(id);
            if (hellos == null)
            {
                return NotFound();
            }

            _context.Hellos.Remove(hellos);
            await _context.SaveChangesAsync();

            return hellos;
        }

        private bool HellosExists(int? id)
        {
            return _context.Hellos.Any(e => e.Id == id);
        }
    }
}
