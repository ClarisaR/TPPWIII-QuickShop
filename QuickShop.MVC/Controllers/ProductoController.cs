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

            if (Request.Query["clearPrice"] == "true" && filtro != null)
            {
                filtro.PrecioMinimo = 0;
                filtro.PrecioMaximo = double.MaxValue;
            }

            // Obtener base de productos según contexto
            List<ProductoDTO> productosBase;

            if (!string.IsNullOrEmpty(filtro?.RubroSeleccionado))
            {
                productosBase = _productoServicio.ObtenerProductosPorRubro(filtro.RubroSeleccionado).Result;
            }
            else
            {
                productosBase = _productoServicio.ObtenerProductos().Result;
            }

            if (productosBase == null)
                productosBase = new List<ProductoDTO>();


            // Aplicar filtros
            bool tieneFiltros = filtro != null && (
                (filtro.Categorias?.Any() == true) ||
                (filtro.Colores?.Any() == true) ||
                (filtro.Talles?.Any() == true) ||
                (filtro.Rubros?.Any() == true) ||
                (filtro.PrecioMinimo > 0) ||
                (filtro.PrecioMaximo < double.MaxValue)
            );

            var productos = tieneFiltros
                ? _productoServicio.FiltrarProductosDesdeLista(filtro, productosBase).Result
                : productosBase;

            // Aplicar orden si corresponde
            if (filtro != null && !string.IsNullOrEmpty(filtro.Orden))
            {
                productos = filtro.Orden switch
                {
                    "precioAsc" => productos.OrderBy(p => p.Precio).ToList(),
                    "precioDesc" => productos.OrderByDescending(p => p.Precio).ToList(),
                    _ => productos
                };
            }

            return RetornarVistaConProductos(productos, filtro);
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
        public IActionResult MostrarProductosPorNombre(string nombre, FiltroDTO? filtro)
        {
            CargarEnumsEnViewBag();
            var productos = _productoServicio.ObtenerProductosPorNombre(nombre).Result;
            return RetornarVistaConProductos(productos, filtro);
        }

        [HttpGet]
        [Route("Producto/Rubro/{rubro}")]
        public async Task<IActionResult> MostrarProductosPorRubro(string rubro)
        {
            CargarEnumsEnViewBag();
            var productos = await _productoServicio.ObtenerProductosPorRubro(rubro);
            var filtro = new FiltroDTO
            {
                RubroSeleccionado = rubro
            };

            var viewModel = new ProductosViewModel
            {
                Productos = productos,
                Filtro = filtro
            };

            return View("MostrarProductos", viewModel);
        }

        [HttpGet]
        [Route("Producto/Color/{color}")]
        public IActionResult MostrarProductosPorColor(string color)
        {
            CargarEnumsEnViewBag();
            var productos = _productoServicio.ObtenerProductosPorColor(color).Result;
            return RetornarVistaConProductos(productos);
        }

        [HttpGet]
        [Route("Producto/Categoria/{categoria}")]
        public IActionResult MostrarProductosPorCategoria(string categoria)
        {
            CargarEnumsEnViewBag();
            var productos = _productoServicio.ObtenerProductosPorCategoria(categoria).Result;
            return RetornarVistaConProductos(productos);
        }
    }
}
