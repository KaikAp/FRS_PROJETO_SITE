using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class RegistroPedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReceberDados([FromBody] PedidoData dados)
        {
            dados.DescricaoPedido = dados.DescricaoPedido.ToString() + "aaaaa";
            // Processar os dados recebidos
            return Json(new { success = true, message = "Dados recebidos com sucesso!" });
        }
    }

    public class PedidoData
    {
        public string NomePedido { get; set; }
        public string DescricaoPedido { get; set; }
        public List<Topico> Topicos { get; set; } = new List<Topico>();
    }
    public class Topico
    {
        public string Nome { get; set; }
        public List<Passo> Passos { get; set; } = new List<Passo>();
    }

    public class Passo
    {
        public string Nome { get; set; }
    }
}
