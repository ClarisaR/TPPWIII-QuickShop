using Microsoft.AspNetCore.Mvc;
using QuickShop.MVC.Models;
using QuickShop.MVC.Services;
using System.Diagnostics;

namespace QuickShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocalServicio _localServicio;

        public HomeController(ILocalServicio localServicio)
        {
            _localServicio = localServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
