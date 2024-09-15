namespace Business
{
    public class Pessoa
    {
        private int Id { get; set; }
        private string Login { get; set; }
        private string Senha { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }
        private string Telefone { get; set; }
        private string Cidade { get; set; }
        private string Rua { get; set; }
        private int Bairro { get; set; }
        private DateTime DataNascimento { get; set; }
        private DateTime DataCadastro { get; set; }
        private bool Ativo { get; set; }
    }
}
