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
    public class TbasController : ControllerBase
    {
        private readonly Substation_ManagementContext _context;

        public TbasController(Substation_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/Tbas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tba>>> GetTba()
        {
            return await _context.Tba.ToListAsync();
        }

        // GET: api/Tbas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tba>> GetTba(int id)
        {
            var tba = await _context.Tba.FindAsync(id);

            if (tba == null)
            {
                return NotFound();
            }

            return tba;
        }

        // PUT: api/Tbas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTba(int id, Tba tba)
        {
            if (id != tba.Id)
            {
                return BadRequest();
            }

            _context.Entry(tba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbaExists(id))
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

        // POST: api/Tbas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tba>> PostTba(Tba tba)
        {
            _context.Tba.Add(tba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTba", new { id = tba.Id }, tba);
        }

        // DELETE: api/Tbas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tba>> DeleteTba(int id)
        {
            var tba = await _context.Tba.FindAsync(id);
            if (tba == null)
            {
                return NotFound();
            }

            _context.Tba.Remove(tba);
            await _context.SaveChangesAsync();

            return tba;
        }

        private bool TbaExists(int id)
        {
            return _context.Tba.Any(e => e.Id == id);
        }
    }
}
