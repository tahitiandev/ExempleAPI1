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
    public class PieceController : ControllerBase
    {
        private readonly GeststockContext _context;

        public PieceController(GeststockContext context)
        {
            _context = context;
        }

        // GET: api/Piece
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceModel>>> GetPiece()
        {
            return await _context.Piece.ToListAsync();
        }

        // GET: api/Piece/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PieceModel>> GetPieceModel(int id)
        {
            var pieceModel = await _context.Piece.FindAsync(id);

            if (pieceModel == null)
            {
                return NotFound();
            }

            return pieceModel;
        }

        // PUT: api/Piece/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPieceModel(int id, PieceModel pieceModel)
        {
            if (id != pieceModel.IdPiece)
            {
                return BadRequest();
            }

            _context.Entry(pieceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceModelExists(id))
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

        // POST: api/Piece
        [HttpPost]
        public async Task<ActionResult<PieceModel>> PostPieceModel(Pieces t)
        {

            var s = new PieceModel
            {
                Code = t.Code,
                Libelle = t.Libelle
            };

            _context.Piece.Add(s);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPieceModel", new { IdPiece = "" }, s);
        }

        // DELETE: api/Piece/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PieceModel>> DeletePieceModel(int id)
        {
            var pieceModel = await _context.Piece.FindAsync(id);
            if (pieceModel == null)
            {
                return NotFound();
            }

            _context.Piece.Remove(pieceModel);
            await _context.SaveChangesAsync();

            return pieceModel;
        }

        private bool PieceModelExists(int id)
        {
            return _context.Piece.Any(e => e.IdPiece == id);
        }
    }
}
