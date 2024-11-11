using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class RegistroClienteController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
