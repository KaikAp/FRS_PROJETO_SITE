using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class RegistroPedidoController : Controller
    {
        private Context _context;

        public RegistroPedidoController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Cliente> cliente = new Cliente().BuscarTodos(_context).ToList();

            var ClienteList = cliente.Select(c => new SelectListItem() { Text = c.Pessoa.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.Categorias = ClienteList;

            return View();
        }

        [HttpPost]
        public IActionResult ReceberDados([FromBody] PedidoViewModel pedidoData)
        {
            try
            {
                var pedido = new Pedido
                {
                    Nome = pedidoData.NomePedido,
                    Descricao = pedidoData.DescricaoPedido,
                    FuncionarioId = 1,
                    ClienteId = pedidoData.ClienteId,
                    DataInicio = pedidoData.dataInicioProjeto,
                    DataTermino = pedidoData.dataFimProjeto,
                    Topicos = new List<Topico>()
                };

                foreach (var topicoViewModel in pedidoData.Topicos)
                {
                    var topico = new Topico
                    {
                        Nome = topicoViewModel.Nome,
                        DataInicio = topicoViewModel.dataInicio,
                        DataTermino = topicoViewModel.dataFim,
                        SubTopicos = new List<SubTopico>()
                    };

                    foreach (var passoViewModel in topicoViewModel.SubTopicos)
                    {
                        var passo = new SubTopico
                        {
                            Nome = passoViewModel.Nome,
                            DataInicio = passoViewModel.dataInicio,
                            DataTermino = passoViewModel.dataFim
                        };

                        topico.SubTopicos.Add(passo);
                    }

                    pedido.Topicos.Add(topico);
                }

                pedido.Salvar(_context);

                return Json(new { success = true });

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return Json(new { success = false, error = "Erro ao salvar o pedido" });
            }
        }


    }

    public class PedidoViewModel
    {
        public int ClienteId { get; set; }
        public string NomePedido { get; set; }
        public DateTime dataInicioProjeto { get; set; }
        public DateTime dataFimProjeto { get; set; }
        public string DescricaoPedido { get; set; }
        public List<TopicoViewModel> Topicos { get; set; }
    }

    public class TopicoViewModel
    {
        public string Nome { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime? dataFim { get; set; }
        public List<SubTopicoViewModel> SubTopicos { get; set; }
    }

    public class SubTopicoViewModel
    {
        public string Nome { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime? dataFim { get; set; }
    }
}
