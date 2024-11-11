using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class TopicoController : Controller
    {
        private Context _context;

        public TopicoController(Context context)
        {
            _context = context;
        }

        public IActionResult Edit(int id)
        {
            Topico topico = new Topico().BuscarPorId(_context, id);
            topico.SubTopicos = new SubTopico().BusccarPorIdTopico(_context, topico.Id);
            return View(topico);
        }

        [HttpPost]
        public ActionResult Edit(Topico topicoAlterado)
        {
            try
            {
                Topico topico =
                    new Topico().BuscarPorId(_context, topicoAlterado.Id);

                topico.Nome = topicoAlterado.Nome;
                topico.DataInicio = topicoAlterado.DataInicio;
                topico.DataTermino = topicoAlterado.DataTermino;

                topico.Alterar(_context);

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
            var topico = _context.Topicos.FirstOrDefault(p => p.Id == id);
            if (topico == null)
            {
                return NotFound();
            }

            return View(topico);
        }

        // Ação para realizar a exclusão
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var topico = _context.Topicos
                    .Include(t => t.SubTopicos) // Inclui os Subtopicos do Topico
                    .FirstOrDefault(t => t.Id == id);
                if (topico != null)
                {
                    // Remove todos os Subtopicos associados ao Topico
                    if (topico.SubTopicos != null)
                    {
                        topico.RemoveRangeSubTopicos(_context);
                    }

                    // Remove o Topico
                    topico.Remover(_context);

                    // Salva as mudanças no banco de dados
                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "PerfilFuncionario");
            }
            catch (DbUpdateException ex)
            {
                // Loga a exceção e exibe uma mensagem de erro personalizada
                Console.WriteLine("Erro ao salvar alterações: " + ex.InnerException?.Message);
                return View();
            }
        }
    }
}
