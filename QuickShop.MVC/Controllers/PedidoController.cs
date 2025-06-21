using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Services;

namespace QuickShop.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoServicio _pedidoServicio;

        private readonly IHttpContextAccessor httpContext;
        public PedidoController(IPedidoServicio pedidoServicio, IHttpContextAccessor httpContext)
        {
            _pedidoServicio = pedidoServicio;

            this.httpContext = httpContext;
        }

        [HttpGet("{id}")]
        public IActionResult VerPedido(int id)
        {
            
            var pedido = _pedidoServicio.ObtenerPedido(id).Result;

            if (pedido == null)
            {
                ModelState.AddModelError("", "Pedido no encontrado o no tienes permiso para verlo.");
                return RedirectToAction("MisPedidos");
            }
            return View(pedido);
        }

        [HttpGet]
        public IActionResult MisPedidos()
        {
            var token = Request.Cookies["jwt"];
            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "Debes iniciar sesión para crear un pedido.");
                return RedirectToAction("Login", "Usuario");
            }
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);
            if (jwtToken == null)
            {
                ModelState.AddModelError("", "Token JWT inválido.");
                return RedirectToAction("Login", "Usuario");
            }
            var idUsuario = Int32.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
            if (idUsuario == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var pedidos = _pedidoServicio.ObtenerPedidosDeUsuario(idUsuario).Result;
            return View(pedidos);
        }

        [HttpPost]
        public IActionResult CrearPedido(CrearPedidoDTO pedido)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies["jwt"];
                if (string.IsNullOrEmpty(token))
                {
                    ModelState.AddModelError("", "Debes iniciar sesión para crear un pedido.");
                    return RedirectToAction("Login", "Usuario");
                }
                var handler = new JwtSecurityTokenHandler();

                var jwtToken = handler.ReadJwtToken(token);
                if (jwtToken == null)
                {
                    ModelState.AddModelError("", "Token JWT inválido.");
                    return RedirectToAction("Login", "Usuario");
                }
                pedido.IdUsuario = Int32.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value);

                var resultado = _pedidoServicio.CrearPedido(pedido).Result;
                if (resultado)
                {
                    return RedirectToAction("MisPedidos");
                }
                else
                {
                    ModelState.AddModelError("", "Error al crear el pedido. Inténtalo de nuevo.");
                }
            }
            return View(pedido);
        }

        [HttpGet]
        public IActionResult VerPedidos()
        {
            var pedidos = _pedidoServicio.ObtenerTodosLosPedidos().Result;
            return View("MisPedidos", pedidos);
        }
    }
}
