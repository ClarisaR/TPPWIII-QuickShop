using Microsoft.AspNetCore.Mvc;

namespace QuickShop.MVC.Controllers
{
    public class PagoController : Controller
    {

        [HttpGet]
        public IActionResult ProcesoPago()
        {
            return View();
        }
    }
}
