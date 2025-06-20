using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Services;

namespace QuickShop.MVC.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IProductoServicio _productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
           _productoServicio = productoServicio;
        }

        [HttpGet]
        public IActionResult MostrarProductos(FiltroDTO? filtro)
        {
            List<ProductoDTO> productos = (filtro != null) 
                            ? _productoServicio.ObtenerProductos().Result  
                            : _productoServicio.FiltrarProductos(filtro).Result;
           
            return View(productos);
        }

        [HttpGet]
        [Route("Producto/Detalle/{id}")]
        public IActionResult Detalles(int id)
        {
            ProductoDTO producto = _productoServicio.ObtenerProducto(id).Result;
            ViewBag.ProductosSimilares = _productoServicio.ObtenerProductosSimilares(id).Result;
            ViewBag.ProductosDelLocal = _productoServicio.ObtenerProductosPorLocal(producto.LocalId).Result;
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

        [Route("Producto/Color/{color}")]
        public IActionResult MostrarProductosPorColor(string color)
        {
            List<ProductoDTO> productos = _productoServicio.ObtenerProductosPorColor(color).Result;
            return View("MostrarProductos", productos);
        }

        [Route("Producto/Categoria/{Categoria}")]
        public IActionResult MostrarProductosPorCategproa(string categoria)
        {
            List<ProductoDTO> productos = _productoServicio.ObtenerProductosPorCategoria(categoria).Result;
            return View("MostrarProductos", productos);
        }
    }
}
