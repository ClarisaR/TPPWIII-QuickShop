using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Data;
using Productos.Models;
using Productos.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalesController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalesController(ILocalService localService)
        {
            _localService = localService;
        }

        // GET: api/Locales
        [HttpGet]
        public async Task<ActionResult<List<Local>>> GetLocales()
        {
            var locales = await _localService.ObtenerLocales();
            if (locales == null || !locales.Any())
            {
                return NotFound("No se encontraron locales.");
            }
            return Ok(locales);
        }

        // GET api/Locales/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetLocal(int id)
        {
            var local = await _localService.ObtenerLocalPorId(id);
            if (local == null) return NotFound();
            return Ok(local);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(Local local)
        {
            if (local == null) return BadRequest("El local no puede ser nulo.");

            var createdLocal = await _localService.CrearLocal(local);
            return CreatedAtAction(nameof(GetLocal), new { id = createdLocal.Id }, createdLocal);
        }

        // DELETE api/Locales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocal(int id)
        {
            var result = await _localService.EliminarLocal(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
