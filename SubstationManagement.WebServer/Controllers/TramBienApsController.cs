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
    public class TramBienApsController : ControllerBase
    {
        private readonly Substation_ManagementContext _context;

        public TramBienApsController(Substation_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/TramBienAps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TramBienAp>>> GetTramBienAp()
        {
            return await _context.TramBienAp.ToListAsync();
        }

        // GET: api/TramBienAps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TramBienAp>> GetTramBienAp(int id)
        {
            var tramBienAp = await _context.TramBienAp.FindAsync(id);

            if (tramBienAp == null)
            {
                return NotFound();
            }

            return tramBienAp;
        }

        // PUT: api/TramBienAps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTramBienAp(int id, TramBienAp tramBienAp)
        {
            if (id != tramBienAp.Id)
            {
                return BadRequest();
            }

            _context.Entry(tramBienAp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramBienApExists(id))
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

        // POST: api/TramBienAps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TramBienAp>> PostTramBienAp(TramBienAp tramBienAp)
        {
            _context.TramBienAp.Add(tramBienAp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTramBienAp", new { id = tramBienAp.Id }, tramBienAp);
        }

        // DELETE: api/TramBienAps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TramBienAp>> DeleteTramBienAp(int id)
        {
            var tramBienAp = await _context.TramBienAp.FindAsync(id);
            if (tramBienAp == null)
            {
                return NotFound();
            }

            _context.TramBienAp.Remove(tramBienAp);
            await _context.SaveChangesAsync();

            return tramBienAp;
        }

        private bool TramBienApExists(int id)
        {
            return _context.TramBienAp.Any(e => e.Id == id);
        }
    }
}
