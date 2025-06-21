using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Models.Enums;
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

        private void CargarEnumsEnViewBag()
        {
            ViewBag.Categorias = Enum.GetValues(typeof(CategoriaEnum)).Cast<CategoriaEnum>().Select(c => c.ToString()).ToList();
            ViewBag.Colores = Enum.GetValues(typeof(ColorEnum)).Cast<ColorEnum>().Select(c => c.ToString()).ToList();
            ViewBag.Talles = Enum.GetValues(typeof(TalleEnum)).Cast<TalleEnum>().Select(c => c.ToString()).ToList();
            ViewBag.Rubros = Enum.GetValues(typeof(RubroEnum)).Cast<RubroEnum>().Select(c => c.ToString()).ToList();
        }

        private IActionResult RetornarVistaConProductos(List<ProductoDTO> productos, FiltroDTO? filtro = null)
        {
            CargarEnumsEnViewBag();

            var viewModel = new ProductosViewModel
            {
                Productos = productos,
                Filtro = filtro ?? new FiltroDTO()
            };

            return View("MostrarProductos", viewModel);
        }

        [HttpGet]
        public IActionResult MostrarProductos(FiltroDTO? filtro)
        {
            CargarEnumsEnViewBag();

            bool filtroVacio = filtro == null
                || (!filtro.Categorias.Any() && !filtro.Colores.Any() && !filtro.Talles.Any()
                    && filtro.PrecioMinimo == 0 && filtro.PrecioMaximo == double.MaxValue);

            var productos = filtroVacio
                ? _productoServicio.ObtenerProductos().Result
                : _productoServicio.FiltrarProductos(filtro).Result;

            var viewModel = new ProductosViewModel
            {
                Productos = productos,
                Filtro = filtro ?? new FiltroDTO()
            };

            return View(viewModel);
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

        [HttpGet]
        [Route("Producto/Nombre/{nombre}")]
        public IActionResult MostrarProductosPorNombre(string nombre, FiltroDTO? filtro)
        {
            var productos = _productoServicio.ObtenerProductosPorNombre(nombre).Result;
            return RetornarVistaConProductos(productos, filtro);
        }

        [HttpGet]
        [Route("Producto/Rubro/{rubro}")]
        public IActionResult MostrarProductosPorRubro(string rubro)
        {
            var productos = _productoServicio.ObtenerProductosPorRubro(rubro).Result;
            return RetornarVistaConProductos(productos);
        }

        [HttpGet]
        [Route("Producto/Color/{color}")]
        public IActionResult MostrarProductosPorColor(string color)
        {
            var productos = _productoServicio.ObtenerProductosPorColor(color).Result;
            return RetornarVistaConProductos(productos);
        }

        [HttpGet]
        [Route("Producto/Categoria/{categoria}")]
        public IActionResult MostrarProductosPorCategoria(string categoria)
        {
            var productos = _productoServicio.ObtenerProductosPorCategoria(categoria).Result;
            return RetornarVistaConProductos(productos);
        }
    }
}
