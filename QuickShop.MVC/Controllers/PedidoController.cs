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
        private readonly IProductoServicio _productoServicio;
        public PedidoController(IPedidoServicio pedidoServicio, IProductoServicio productoServicio, IHttpContextAccessor httpContext)
        {
            _pedidoServicio = pedidoServicio;
            _productoServicio = productoServicio;
            this.httpContext = httpContext;
        }

        [HttpGet]
        public IActionResult VerPedido(int id)
        {
            var pedido = _pedidoServicio.ObtenerPedido(id).Result;
            var detallesPedido = _pedidoServicio.ObtenerDetallesPedido(id).Result;

            if (pedido == null)
            {
                ModelState.AddModelError("", "Pedido no encontrado.");
                return RedirectToAction("MisPedidos");
            }

            var idProductos = detallesPedido.Select(pp => pp.IdProducto).ToList();
            var productos = _productoServicio.ObtenerProductosPorIds(idProductos).Result;

            var detallesViewModel = detallesPedido.Select(dp =>
            {
                var prod = productos.First(p => p.Id == dp.IdProducto);
                return new DetallePedidoViewModel
                {
                    NombreProducto = prod.Nombre,
                    ImagenProducto = prod.Imagen,
                    PrecioUnitario = dp.PrecioUnitario,
                    Cantidad = dp.CantidadProductos
                };
            }).ToList();

            ViewBag.Pedido = pedido;
            return View(detallesViewModel);
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
            
            var pedidos = _pedidoServicio.ObtenerPedidosDeUsuario(idUsuario).Result;
            return View(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoDTO pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = Request.Cookies["jwt"];
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Debes iniciar sesión para crear un pedido.");

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            if (jwtToken == null)
                return Unauthorized("Token JWT inválido.");

            pedido.IdUsuario = int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value);

            var idPedido = await _pedidoServicio.CrearPedido(pedido);

            if (idPedido != null && idPedido > 0)
            {
                return Json(new { success = true, pedidoId = idPedido });
            }

            return StatusCode(500, new { success = false, message = "No se pudo crear el pedido." });
        }



        [HttpGet]
        public IActionResult VerPedidos()
        {
            var pedidos = _pedidoServicio.ObtenerTodosLosPedidos().Result;
            return View("MisPedidos", pedidos);
        }
    }
}
