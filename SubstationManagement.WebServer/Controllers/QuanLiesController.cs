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
    public class QuanLiesController : ControllerBase
    {
        private readonly Substation_ManagementContext _context;

        public QuanLiesController(Substation_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/QuanLies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuanLy>>> GetQuanLy()
        {
            return await _context.QuanLy.ToListAsync();
        }

        // GET: api/QuanLies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuanLy>> GetQuanLy(int id)
        {
            var quanLy = await _context.QuanLy.FindAsync(id);

            if (quanLy == null)
            {
                return NotFound();
            }

            return quanLy;
        }

        // PUT: api/QuanLies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuanLy(int id, QuanLy quanLy)
        {
            if (id != quanLy.Tba)
            {
                return BadRequest();
            }

            _context.Entry(quanLy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuanLyExists(id))
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

        // POST: api/QuanLies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<QuanLy>> PostQuanLy(QuanLy quanLy)
        {
            _context.QuanLy.Add(quanLy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuanLyExists(quanLy.Tba))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuanLy", new { id = quanLy.Tba }, quanLy);
        }

        // DELETE: api/QuanLies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuanLy>> DeleteQuanLy(int id)
        {
            var quanLy = await _context.QuanLy.FindAsync(id);
            if (quanLy == null)
            {
                return NotFound();
            }

            _context.QuanLy.Remove(quanLy);
            await _context.SaveChangesAsync();

            return quanLy;
        }

        private bool QuanLyExists(int id)
        {
            return _context.QuanLy.Any(e => e.Tba == id);
        }
    }
}
