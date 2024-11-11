using FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class PerfilFuncionarioController : Controller
    {
        private Context _context;

        public PerfilFuncionarioController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Cliente> cliente = new Cliente().BuscarTodos(_context).ToList();

            var ClienteList = cliente.Select(c => new SelectListItem() { Text = c.Pessoa.Nome, Value = c.Pessoa.Id.ToString() }).ToList();

            ViewBag.Cliente = ClienteList;
            
            return View();
        }

        public IActionResult ClientePedidos(int id)
        {
            Pessoa pessoa = new Pessoa().BuscarPorId(_context, id);
            Cliente cliente = new Cliente().BuscarPorId(_context, pessoa.Id);
            List<Telefone> telefones = new Telefone().BuscarPorIdPessoa(_context, pessoa.Id);
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

        public IActionResult ClienteEdit(int id)
        {
            Pessoa pessoa = new Pessoa().BuscarPorId(_context, id);
            Cliente cliente = new Cliente().BuscarPorIdPessoa(_context, pessoa.Id);
            List<Telefone> telefones = new Telefone().BuscarPorIdPessoa(_context, pessoa.Id);

            ClienteTelefone clientePedido = new ClienteTelefone
            {
                Cliente = cliente,
                Pessoa = pessoa,
                Telefones = telefones,
                PessoaId = pessoa.Id
            };

            return View(clientePedido);
        }

        [HttpPost]
        public ActionResult ClienteEdit(ClienteTelefone clienteAlterado)
        {
            try
            {
                Cliente cliente = new Cliente().BuscarPorIdPessoa(_context, clienteAlterado.PessoaId);
                Pessoa pessoa = new Pessoa().BuscarPorId(_context, clienteAlterado.PessoaId);
                List<Telefone> telefones = new Telefone().BuscarPorIdPessoa(_context, clienteAlterado.PessoaId);
                int clienteId = cliente.Id;

                pessoa.Bairro = clienteAlterado.Pessoa.Bairro;
                pessoa.Cep = clienteAlterado.Pessoa.Cep;
                pessoa.Cidade = clienteAlterado.Pessoa.Cidade;
                pessoa.Email = clienteAlterado.Pessoa.Email;
                pessoa.Nome = clienteAlterado.Pessoa.Nome;
                pessoa.DataNascimento = clienteAlterado.Pessoa.DataNascimento;
                pessoa.Uf = clienteAlterado.Pessoa.Uf;
                pessoa.Rua = clienteAlterado.Pessoa.Rua;
                pessoa.NResidencia = clienteAlterado.Pessoa.NResidencia;
                pessoa.Ativo = clienteAlterado.Pessoa.Ativo;

                cliente.Cnpj = clienteAlterado.Cliente.Cnpj;

                telefones = clienteAlterado.Telefones;

                pessoa.Alterar(_context);
                cliente.Alterar(_context);
                foreach(var telefone in telefones)
                {
                    int numero = 0;
                    telefone.NTelefone = clienteAlterado.Telefones[numero].NTelefone;
                    telefone.Alterar(_context);
                    numero++;
                }

                return RedirectToAction("Index", "PerfilFuncionario");
            }
            catch
            {
                return View();
            }
        }
    }
}
