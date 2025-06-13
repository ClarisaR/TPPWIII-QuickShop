using Microsoft.AspNetCore.Mvc;
using Autenticacion.Models;
using Autenticacion.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autenticacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly JwtService _jwtService;
        public AutenticacionController(HttpClient httpClient, JwtService jwtService) 
        { 
            _httpClient = httpClient;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var respuesta = await _httpClient.GetAsync($"http://usuarios-api:8080/api/Usuarios/por-email?email={loginRequest.Email}");

            if (!respuesta.IsSuccessStatusCode)
                return Unauthorized("Usuario o contraseña incorrectos");

            var usuario = await respuesta.Content.ReadFromJsonAsync<UsuarioResponse>();

            if (usuario == null || usuario.Contrasenia != HashPassword(loginRequest.Contrasenia))
                return Unauthorized("Usuario o contraseña incorrectos");

            // Si la contraseña coincide, devolvés la respuesta
            var loginResponse = new LoginResponse
            {
                Token = _jwtService.GenerateToken(usuario.Email, usuario.Nombre, usuario.Id)
            };

            return Ok(loginResponse);
        }

        private static string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            // Serializar el objeto a JSON
            var contenido = JsonContent.Create(request);

            // Llamar al microservicio de usuarios para crear el nuevo usuario
            var respuesta = await _httpClient.PostAsync("http://usuarios-api:8080/api/Usuarios", contenido);

            if (!respuesta.IsSuccessStatusCode)
                return BadRequest("No se pudo registrar el usuario");

            // (Opcional) Leer la respuesta del microservicio
            var usuario = await respuesta.Content.ReadFromJsonAsync<UsuarioResponse>();

            return Created("Usuario registrado con exito", usuario);
        }


        // GET: api/<AutenticacionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AutenticacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<AutenticacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutenticacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
