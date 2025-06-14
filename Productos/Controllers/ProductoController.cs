using Microsoft.AspNetCore.Mvc;
using Productos.Services;

namespace Productos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoService.GetProductos();
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos.");
            }

            return Ok(productos);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productoService.GetProducto(id);
            if (producto == null)
            {
                return NotFound($"No se encontró el producto con ID = {id}");
            }
            return Ok(producto);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductoPorNombre(string nombre)
        {
            var producto = await _productoService.GetProductoPorNombre(nombre);
            if(producto == null)
            {
                return NotFound($"No se encontró el producto {nombre}");
            }
            return Ok(producto);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductoPorRubro(string rubro)
        {
            var productos = await _productoService.GetProductosPorRubro(rubro);
            if(productos == null || !productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }
            return Ok(productos);
        }
    }
}
