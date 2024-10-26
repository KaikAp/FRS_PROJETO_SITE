using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class CadastroController : Controller
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
