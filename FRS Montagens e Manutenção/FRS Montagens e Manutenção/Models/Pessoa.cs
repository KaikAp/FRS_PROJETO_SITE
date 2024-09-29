namespace FRS_Montagens_e_Manutenção.Models
{
    public class Pessoa
    {
        //Getters Setters
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
        public char Uf {  get; set; }
        public string Cidade { get; set; }
        public int Bairro { get; set; }
        public string Rua { get; set; }
        public string NResidencia { get; set; }
        public string Cep {  get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual List<Cliente> ClientesPessoa { get; set; }
        public virtual List<Funcionario> FuncionarioPessoa { get; set; }
        
        //Construtores


        //Metodos
    }
}
