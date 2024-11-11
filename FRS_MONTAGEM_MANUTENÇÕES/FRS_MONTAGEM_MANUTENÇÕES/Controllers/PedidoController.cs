using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
