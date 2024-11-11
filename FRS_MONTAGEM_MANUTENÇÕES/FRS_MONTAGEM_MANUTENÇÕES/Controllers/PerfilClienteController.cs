using FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    [Authorize]
    public class PerfilClienteController : Controller
    {
        private Context _context;

        public PerfilClienteController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("index");
        }

    }
}
