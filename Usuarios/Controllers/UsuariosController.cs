using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Usuarios.Models;
using Usuarios.Data;
using Usuarios.Models.DTO;
using Microsoft.AspNetCore.Identity;

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

        //GET: /api/Usuarios?email={email}
        [HttpGet("por-email")]
        public async Task<IActionResult> GetUsuarioPorEmail([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("El email es obligatorio.");

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
                return NotFound($"No se encontró un usuario con el email '{email}'.");

            // Si no querés devolver toda la entidad (por seguridad), podés crear un DTO
            var usuarioDto = new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Email,
                usuario.Contrasenia,
                usuario.Telefono,
                usuario.Direccion
            };

            return Ok(usuarioDto);
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
                Contrasenia = HashPassword(crearUsuarioDto.Contrasenia),
                Telefono = crearUsuarioDto.Telefono,
                Direccion = crearUsuarioDto.Direccion ?? string.Empty
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        private static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
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
