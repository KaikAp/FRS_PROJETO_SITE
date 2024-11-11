using FRS_Montagens_e_Manutenção.Models;

namespace FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels
{
    public class ClienteTelefone
    {
        public Pessoa Pessoa { get; set; }
        public Cliente Cliente { get; set; }
        public List<Telefone> Telefones { get; set; }
        public int PessoaId { get; set; }
    }
}
