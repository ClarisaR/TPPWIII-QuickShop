using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuickShop.MVC.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IProductoServicio _productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
            this._productoServicio = productoServicio;
        }

        [HttpGet]
        public IActionResult MostrarProductos()
        {
            List<ProductoDTO> productos = _productoServicio.ObtenerProductos().Result;
            return View(productos);
        }

        [HttpGet]
        [Route("Producto/Detalle/{id}")]
        public IActionResult Detalles(int id)
        {
            ProductoDTO producto = _productoServicio.ObtenerProducto(id).Result;
            return View(producto);
        }

        [Route("Producto/Nombre/{nombre}")]
        public IActionResult MostrarProductosPorNombre(string nombre) 
        {
            List<ProductoDTO> productos = _productoServicio.ObtenerProductosPorNombre(nombre).Result;

            return View("MostrarProductos", productos);
        }

        [Route("Producto/Rubro/{rubro}")]
        public IActionResult MostrarProductosPorRubro(string rubro)
        {
            List<ProductoDTO> productos = _productoServicio.ObtenerProductosPorRubro(rubro).Result;

            return View("MostrarProductos", productos);
        }
    }
}
