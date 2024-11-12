using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class SubTopicoController : Controller
    {
        private Context _context;

        public SubTopicoController(Context context)
        {
            _context = context;
        }

        public IActionResult Edit(int id)
        {
            SubTopico subTopico = new SubTopico().BuscarPorId(_context, id);
            return View(subTopico);
        }

        [HttpPost]
        public ActionResult Edit(SubTopico subTopicoAlterado)
        {
            try
            {
                SubTopico subTopico =
                    new SubTopico().BuscarPorId(_context, subTopicoAlterado.Id);

                subTopico.Nome = subTopicoAlterado.Nome;
                subTopico.DataInicio = subTopicoAlterado.DataInicio;
                subTopico.DataTermino = subTopicoAlterado.DataTermino;

                subTopico.Alterar(_context);

                var topico = _context.Topicos.Where(a => a.Id == subTopico.TopicoId).FirstOrDefault();
                var pedido = _context.Pedidos.Where(a => a.Id == topico.Id).FirstOrDefault();

                return RedirectToAction("ClientePedidos", "PerfilFuncionario", new { id = pedido.ClienteId });
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            var Subtopicos = _context.SubTopicos.FirstOrDefault(p => p.Id == id);
            if (Subtopicos == null)
            {
                return NotFound();
            }

            return View(Subtopicos);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var subTopico = _context.SubTopicos.FirstOrDefault(t => t.Id == id);
                if (subTopico != null)
                {
                    subTopico.Remover(_context);

                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "PerfilFuncionario");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Erro ao salvar alterações: " + ex.InnerException?.Message);
                return View();
            }
        }
    }
}
