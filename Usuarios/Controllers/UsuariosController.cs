using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Usuarios.Models;
using Usuarios.Data;
using Usuarios.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioDbContext _context;

        public UsuariosController(UsuarioDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(CrearUsuarioDTO crearUsuarioDto)
        {
            // Mapear el DTO a la entidad Usuario
            var usuario = new Usuario
            {
                Nombre = crearUsuarioDto.Nombre,
                Apellido = crearUsuarioDto.Apellido,
                Email = crearUsuarioDto.Email,
                Contrasenia = crearUsuarioDto.Contrasenia,
                Telefono = crearUsuarioDto.Telefono,
                Direccion = crearUsuarioDto.Direccion ?? string.Empty
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, ActualizarUsuarioDTO actualizarUsuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre = actualizarUsuarioDto.Nombre ?? usuario.Nombre;
            usuario.Apellido = actualizarUsuarioDto.Apellido ?? usuario.Apellido;
            usuario.Contrasenia = actualizarUsuarioDto.Contrasenia ?? usuario.Contrasenia;
            usuario.Telefono = actualizarUsuarioDto.Telefono ?? usuario.Telefono;
            usuario.Email = actualizarUsuarioDto.Email ?? usuario.Email; 
            usuario.Direccion = actualizarUsuarioDto.Direccion ?? usuario.Direccion;

            await _context.SaveChangesAsync(); // Guarda los cambios

            return Ok();

        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
