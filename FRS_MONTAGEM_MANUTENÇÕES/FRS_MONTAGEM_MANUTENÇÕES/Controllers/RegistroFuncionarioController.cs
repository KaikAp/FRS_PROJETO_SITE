using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    [Authorize]
    public class RegistroFuncionarioController : Controller
    {

        // GET: CadastroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CadastroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFuncionario(Pessoa pessoa)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return View();
                }
                return View();
            }
            catch
            {
                return View("index");
            }
        }
    }
}
