using FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    [Authorize]
    public class PerfilFuncionarioController : Controller
    {
        private Context _context;

        public PerfilFuncionarioController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(Pessoa pessoa)
        {
            List<Cliente> cliente = new Cliente().BuscarTodos(_context).ToList();

            var ClienteList = cliente.Select(c => new SelectListItem() { Text = c.Pessoa.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.Cliente = ClienteList;
            
            return View("index", pessoa);
        }

        public IActionResult ClientePedidos(int id)
        {
            var cliente = new Cliente().BuscarPorId(_context, id);
            var pessoa = new Pessoa().BuscarPorIdCliente(_context, cliente.PessoaId);
            var telefones = new Telefone().BuscarPorIdPessoa(_context, pessoa.Id);
            List<Pedido> pedidos = new Pedido().BuscarTodosPorIdCliente(_context, cliente.Id);

            cliente.FormatarCnpj();

            ClientePedido clientePedido = new ClientePedido
            {
                Cliente = cliente,
                Pessoa = pessoa,
                Telefones = telefones,
                Pedidos = pedidos
            };

            return View(clientePedido);
        }
    }
}
