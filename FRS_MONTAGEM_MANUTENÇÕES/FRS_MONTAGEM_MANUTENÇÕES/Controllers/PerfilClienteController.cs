using FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Security.Claims;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    [Authorize]
    public class PerfilClienteController : Controller
    {
        private readonly Context _context;

        public PerfilClienteController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Pessoa pessoa = new Pessoa().BuscarPorId(_context, id);
            Cliente cliente = new Cliente().BuscarPorIdPessoa(_context, id);
            List<Pedido> pedido = new Pedido().BuscarTodosPorIdCliente(_context, cliente.Id);

            ClientePedido clientePedido = new ClientePedido
            {
                Pedidos = pedido,
                Pessoa = pessoa,
                Cliente = cliente
            };

            // a pessoa que vem já vem o usuario que você precisa caso queira tive que fazer do jeito porco pq não tava funfando
            //var idLogado = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); //aqui você consegue pegar o id se quiser
            return View("index", clientePedido);
        }
    }
}
