using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubstationManagement.Entity.Models;

namespace SubstationManagement.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThamSoesController : ControllerBase
    {
        private readonly Substation_ManagementContext _context;

        public ThamSoesController(Substation_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/ThamSoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThamSo>>> GetThamSo()
        {
            return await _context.ThamSo.ToListAsync();
        }

        // GET: api/ThamSoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThamSo>> GetThamSo(int id)
        {
            var thamSo = await _context.ThamSo.FindAsync(id);

            if (thamSo == null)
            {
                return NotFound();
            }

            return thamSo;
        }

        // PUT: api/ThamSoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThamSo(int id, ThamSo thamSo)
        {
            if (id != thamSo.Tba)
            {
                return BadRequest();
            }

            _context.Entry(thamSo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThamSoExists(id))
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

        // POST: api/ThamSoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ThamSo>> PostThamSo(ThamSo thamSo)
        {
            _context.ThamSo.Add(thamSo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThamSoExists(thamSo.Tba))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThamSo", new { id = thamSo.Tba }, thamSo);
        }

        // DELETE: api/ThamSoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThamSo>> DeleteThamSo(int id)
        {
            var thamSo = await _context.ThamSo.FindAsync(id);
            if (thamSo == null)
            {
                return NotFound();
            }

            _context.ThamSo.Remove(thamSo);
            await _context.SaveChangesAsync();

            return thamSo;
        }

        private bool ThamSoExists(int id)
        {
            return _context.ThamSo.Any(e => e.Tba == id);
        }
    }
}
