using Microsoft.AspNetCore.Mvc;
using Productos.Dtos;
using Productos.Models;
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
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var productos = await _productoService.GetProductos();
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos.");
            }

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoService.GetProducto(id);
            if (producto == null)
            {
                return NotFound($"No se encontró el producto con ID = {id}");
            }
            return Ok(producto);
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<List<Producto>>> GetProductoPorNombre(string nombre)
        {
            var producto = await _productoService.GetProductosPorNombre(nombre);
            if (producto == null)
            {
                return NotFound($"No se encontró el producto {nombre}");
            }
            return Ok(producto);
        }

        [HttpGet("rubro/{rubro}")]
        public async Task<ActionResult<List<Producto>>> GetProductoPorRubro(string rubro)
        {
            var productos = await _productoService.GetProductosPorRubro(rubro);
            if (productos == null || !productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }
            return Ok(productos);
        }

        [HttpGet("color/{color}")]
        public async Task<ActionResult<List<Producto>>> GetProductoPorColor(string color)
        {
            var productos = await _productoService.GetProductosPorColor(color);
            if (productos == null || !productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }
            return Ok(productos);
        }

        [HttpGet("talle/{talle}")]
        public async Task<ActionResult<List<Producto>>> GetProductoPorTalle(string talle)
        {
            var productos = await _productoService.GetProductosPorTalle(talle);
            if (productos == null || !productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }
            return Ok(productos);
        }

        [HttpGet("similares/{id}")]
        public async Task<ActionResult<List<Producto>>> GetProductosSimilares(int idProducto)
        {
            var productos = await _productoService.GetProductosSimilares(idProducto);
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos similares.");
            }
            return Ok(productos);
        }

        [HttpGet("local/{id}")]
        public async Task<ActionResult<List<Producto>>> GetProductosDelMismoLocal(int idProducto)
        {
            var productos = await _productoService.GetProductosDelMismoLocal(idProducto);
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos en el local especificado.");
            }
            return Ok(productos);
        }

        [HttpPost("filtrar")]
        public async Task<ActionResult<List<Producto>>> FiltrarProductos([FromBody] FiltroDTO filtro)
        {
            if (filtro == null)
            {
                return BadRequest("El filtro no puede ser nulo.");
            }
            var productos = await _productoService.FiltrarProductos(filtro);
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos que coincidan con los criterios de filtro.");
            }
            return Ok(productos);
        }

        [HttpGet("categoria/{categoria}")]
        public async Task<ActionResult<List<Producto>>> GetProductosPorCategoria(string categoria)
        {
            var productos = await _productoService.GetProductosPorCategoria(categoria);
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos en esta categoría.");
            }
            return Ok(productos);
        }
    }
}
