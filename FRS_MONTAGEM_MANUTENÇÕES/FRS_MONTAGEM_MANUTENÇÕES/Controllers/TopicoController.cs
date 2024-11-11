using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
