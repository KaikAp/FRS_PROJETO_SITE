using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class PedidoController : Controller
    {
        private Context _context;

        public PedidoController(Context context)
        {
            _context = context;
        }

        public IActionResult Edit(int id)
        {
            Pedido pedido = new Pedido().BuscarPorId(_context, id);
            pedido.Topicos = new Topico().BusccarPorIdPedido(_context, id);
            return View(pedido);
        }

        [HttpPost]
        public ActionResult Edit(Pedido pedidoAlterado)
        {
            try
            {
                Pedido pedido =
                    new Pedido().BuscarPorId(_context, pedidoAlterado.Id);

                pedido.Nome = pedidoAlterado.Nome;
                pedido.Descricao = pedidoAlterado.Descricao;
                pedido.DataInicio = pedidoAlterado.DataInicio;
                pedido.DataTermino = pedidoAlterado.DataTermino;

                pedido.Alterar(_context);

                return RedirectToAction("ClientePedidos", "PerfilFuncionario", new { id = pedido.ClienteId });
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var pedido = _context.Pedidos
                   .Include(p => p.Topicos)
                   .ThenInclude(t => t.SubTopicos)
                   .FirstOrDefault(p => p.Id == id);
                if (pedido != null)
                {
                    foreach (var topico in pedido.Topicos)
                    {
                        topico.RemoveRangeSubTopicos(_context); 
                    }

                    pedido.RemoveRangeTopicos(_context);

                    pedido.Remover(_context);

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

        public IActionResult Detalhes(int id)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Topicos)
                .ThenInclude(t => t.SubTopicos)
                .FirstOrDefault(p => p.Id == id);

            return View(pedido);
        }
    }
}

