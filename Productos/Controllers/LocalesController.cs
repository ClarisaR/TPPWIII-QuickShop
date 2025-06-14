using Microsoft.AspNetCore.Mvc;
using Productos.Data;
using Productos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalesController : ControllerBase
    {
        private readonly ProductoDbContext _context;

        public LocalesController(ProductoDbContext context)
        {
            _context = context;
        }

        // GET: api/Locales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocales()
        {
            return await _context.Locales.ToListAsync();
        }

        // GET api/Locales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocal(int id)
        {
            var local = await _context.Locales.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return local;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(Local local)
        {
            if (local == null)
            {
                return BadRequest("El local no puede ser nulo.");
            }
            _context.Locales.Add(local);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLocal), new { id = local.Id }, local);
        }

        // DELETE api/Locales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var local = await _context.Locales.FindAsync(id);
            if (local != null)
            {
                _context.Locales.Remove(local);
                _context.SaveChanges();
            }
            else {
                return NotFound();
            }
            return Ok();
        }
    }
}
