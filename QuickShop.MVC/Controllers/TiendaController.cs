using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Services;

namespace QuickShop.MVC.Controllers
{
    public class TiendaController : Controller
    {
        private readonly ILocalServicio _localServicio;

        public TiendaController(ILocalServicio localServicio)
        {
            _localServicio = localServicio;
        }

        [HttpGet]
        public async Task<IActionResult> VerTiendas()
        {
            List<LocalDTO> locales;
            try
            {
                locales = await _localServicio.ObtenerLocales();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudieron cargar los locales.");
                locales = new List<LocalDTO>();
            }
            return View(locales);
        }

        [HttpGet]
        public async Task<IActionResult> TiendaProductos(int id)
        {
            LocalDTO tienda = await _localServicio.ObtenerLocalConProductos(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return View(tienda);
        }
    }
}
