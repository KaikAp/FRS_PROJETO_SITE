using Microsoft.AspNetCore.Mvc;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar()
        {
            return View();
        }
    }
}
