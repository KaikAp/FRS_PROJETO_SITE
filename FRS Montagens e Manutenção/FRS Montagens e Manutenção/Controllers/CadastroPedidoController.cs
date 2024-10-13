using Microsoft.AspNetCore.Mvc;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class CadastroPedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarTopico()
        {
            return View();
        }
    }
}
