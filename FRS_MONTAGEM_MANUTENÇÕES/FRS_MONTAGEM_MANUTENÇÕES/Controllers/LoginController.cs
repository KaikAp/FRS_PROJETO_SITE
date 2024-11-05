using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar(Pessoa _pessoa)
        {
            try
            {
                _pessoa.Logar(_pessoa);

            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
