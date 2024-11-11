using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class LoginController : Controller
    {
        private Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar(Pessoa _pessoa)
        {
            try
            {
              
                
                List<Claim> claims = [new ]
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
