using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    [Authorize]
    public class PerfilFuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
