using Microsoft.AspNetCore.Mvc;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class PerfilGerente : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
