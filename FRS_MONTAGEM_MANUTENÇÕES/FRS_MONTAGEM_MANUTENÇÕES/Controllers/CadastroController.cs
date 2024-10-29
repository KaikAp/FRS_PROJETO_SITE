using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Context _context;

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
        public ActionResult Create(Context context)
        {
            
            try 
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("index");
            }
        }
    }
}
