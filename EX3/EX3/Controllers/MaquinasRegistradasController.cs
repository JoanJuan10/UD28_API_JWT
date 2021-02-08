using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EX3.Models;
using Microsoft.AspNetCore.Authorization;

namespace EX3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasRegistradasController : ControllerBase
    {
        private readonly ex3Context _context;

        public MaquinasRegistradasController(ex3Context context)
        {
            _context = context;
        }

        // GET: api/MaquinasRegistradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaquinasRegistradas>>> GetMaquinasRegistradas()
        {
            return await _context.MaquinasRegistradas.ToListAsync();
        }

        // GET: api/MaquinasRegistradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinasRegistradas>> GetMaquinasRegistradas(int id)
        {
            var maquinasRegistradas = await _context.MaquinasRegistradas.FindAsync(id);

            if (maquinasRegistradas == null)
            {
                return NotFound();
            }

            return maquinasRegistradas;
        }

        // PUT: api/MaquinasRegistradas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinasRegistradas(int id, MaquinasRegistradas maquinasRegistradas)
        {
            if (id != maquinasRegistradas.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquinasRegistradas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinasRegistradasExists(id))
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

        // POST: api/MaquinasRegistradas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaquinasRegistradas>> PostMaquinasRegistradas(MaquinasRegistradas maquinasRegistradas)
        {
            _context.MaquinasRegistradas.Add(maquinasRegistradas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquinasRegistradas", new { id = maquinasRegistradas.Codigo }, maquinasRegistradas);
        }

        // DELETE: api/MaquinasRegistradas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaquinasRegistradas>> DeleteMaquinasRegistradas(int id)
        {
            var maquinasRegistradas = await _context.MaquinasRegistradas.FindAsync(id);
            if (maquinasRegistradas == null)
            {
                return NotFound();
            }

            _context.MaquinasRegistradas.Remove(maquinasRegistradas);
            await _context.SaveChangesAsync();

            return maquinasRegistradas;
        }

        private bool MaquinasRegistradasExists(int id)
        {
            return _context.MaquinasRegistradas.Any(e => e.Codigo == id);
        }
    }
}
