using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Services;

namespace QuickShop.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServicio usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            this.usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            var registrado = await usuarioServicio.RegistrarUsuario(usuario);

            if (registrado)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Error al registrar el usuario");
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var token = await usuarioServicio.LoginUsuario(login);
            if (token == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(login);
            }

            // guarda el token JWT en una cookie
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            return RedirectToAction("Index", "Home");
        }
    }

}
