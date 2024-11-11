using FRS_Montagens_e_Manutenção.Models;

namespace FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels
{
    public class ClientePedido
    {
        public Pessoa Pessoa { get; set; }
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();
        public Cliente Cliente { get; set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
