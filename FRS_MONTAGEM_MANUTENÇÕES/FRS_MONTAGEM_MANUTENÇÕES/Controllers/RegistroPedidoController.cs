using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    [Authorize]
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
        public IActionResult ReceberDados([FromBody] PedidoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Cria a instância de Pedido a partir da ViewModel
                    var pedido = new Pedido
                    {
                        Nome = model.NomePedido,
                        Descricao = model.DescricaoPedido,
                        FuncionarioId = 1,
                        ClienteId = model.ClienteId,
                        DataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                        Topicos = new List<Topico>()
                    };

                    // Mapeia cada Topico da ViewModel para a entidade Topico
                    foreach (var topicoViewModel in model.Topicos)
                    {
                        var topico = new Topico
                        {
                            Nome = topicoViewModel.Nome,
                            SubTopicos = new List<SubTopico>()
                        };

                        // Mapeia cada Passo da ViewModel para a entidade Passo
                        foreach (var passoViewModel in topicoViewModel.Passos)
                        {
                            var passo = new SubTopico
                            {
                                Nome = passoViewModel.Nome
                            };

                            topico.SubTopicos.Add(passo); // Adiciona o passo ao tópico
                        }

                        pedido.Topicos.Add(topico); // Adiciona o tópico ao pedido
                    }

                    // Salva o Pedido (incluindo tópicos e passos) no banco de dados
                    _context.Pedidos.Add(pedido);
                    _context.SaveChanges();

                    return RedirectToAction("Index"); // Redireciona para a página de confirmação ou listagem
                }

                return View(model); // Retorna a view com erros de validação, se houver
            }
            catch (DbUpdateException ex)
            {
                // Exibe a mensagem da exceção interna para obter mais detalhes
                Console.WriteLine(ex.InnerException?.Message);
                throw; // Re-throw para manter o erro, ou trate conforme necessário
            }
        }
    }

    public class PedidoViewModel
    {
        public int ClienteId { get; set; }
        public string NomePedido { get; set; }
        public string DescricaoPedido { get; set; }
        public List<TopicoViewModel> Topicos { get; set; }
    }

    public class TopicoViewModel
    {
        public string Nome { get; set; }
        public List<SubTopicoViewModel> Passos { get; set; }
    }

    public class SubTopicoViewModel
    {
        public string Nome { get; set; }
    }
}
