using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using geststock.Models;
using geststock.Models.Parametrage;
using geststock.Controllers.Models;

namespace geststock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly GeststockContext _context;

        public TransportController(GeststockContext context)
        {
            _context = context;
        }

        // GET: api/Transport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transport>>> GetTransport()
        {
            return await _context.Transport.ToListAsync();
        }

        // GET: api/Transport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transport>> GetTransport(string id)
        {
            var transport = await _context.Transport.FindAsync(id);

            if (transport == null)
            {
                return NotFound();
            }

            return transport;
        }

        // PUT: api/Transport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransport(string id, Transport transport)
        {
            if (id != transport.Code)
            {
                return BadRequest();
            }

            _context.Entry(transport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(id))
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

        // POST: api/Transport
        [HttpPost]
        public async Task<ActionResult<Transport>> PostTransport(Transports transport)
        {
            var model = new Transport
            {
                Code = transport.Code,
                Libelle = transport.Libelle,
                Voix = transport.Voix

            };

            _context.Transport.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransport", new { id = transport.Code }, model);
        }

        // DELETE: api/Transport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transport>> DeleteTransport(string id)
        {
            var transport = await _context.Transport.FindAsync(id);
            if (transport == null)
            {
                return NotFound();
            }

            _context.Transport.Remove(transport);
            await _context.SaveChangesAsync();

            return transport;
        }

        private bool TransportExists(string id)
        {
            return _context.Transport.Any(e => e.Code == id);
        }
    }
}
