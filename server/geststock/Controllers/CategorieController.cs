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
    public class CategorieController : ControllerBase
    {
        private readonly GeststockContext _context;

        public CategorieController(GeststockContext context)
        {
            _context = context;
        }

        // GET: api/Categorie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategorie()
        {
            return await _context.Categorie.ToListAsync();
        }

        // GET: api/Categorie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
            var categorie = await _context.Categorie.FindAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        // PUT: api/Categorie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
        {
            if (id != categorie.id)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categorie
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostCategorie(Categories cat)
        {

            var categorie = new Categorie
            {

                Libelle = cat.Libelle,
                Description = cat.Description
            };

            _context.Categorie.Add(categorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorie", new { id = "" }, categorie);
            //return CreatedAtAction("GetCategorie", new { id = categorie.Id }, categorie);
        }

        // DELETE: api/Categorie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categorie>> DeleteCategorie(int id)
        {
            var categorie = await _context.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categorie.Remove(categorie);
            await _context.SaveChangesAsync();

            return categorie;
        }

        private bool CategorieExists(int id)
        {
            return _context.Categorie.Any(e => e.id == id);
        }
    }
}
