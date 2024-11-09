using FRS_Montagens_e_Manutenção.Models;

namespace FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels
{
    public class PessoaClienteTelefone
    {
        // Propriedades da Pessoa
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string NResidencia { get; set; }
        public bool Ativo { get; set; }

        // Propriedades do Cliente
        public int ClienteId { get; set; }
        public string Cnpj { get; set; }

        // Lista de Telefones
        public List<Telefone> Telefones { get; set; }
    }
}
