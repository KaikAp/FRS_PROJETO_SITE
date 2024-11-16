using FRS_Montagens_e_Manutenção.Models;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Repository
{
    public class DBInitializer
    {
        public static void Initialize(Context context)
        {
            // Certifica-se de que o banco de dados está criado
            context.Database.EnsureCreated();

            // Verifica se já existe um Funcionario master para evitar duplicação
            if (context.Funcionarios.Any(f => f.Pessoa.Nome == "Master"))
            {
                return; // O banco já foi populado
            }

            // Cria uma nova instância de Pessoa para o Funcionario master
            var pessoaMaster = new Pessoa
            {
                Nome = "Master",
                Email = "master@exemplo.com",
                Senha = "senha123", // Considerar hash para segurança
                Uf = "SP",
                Cidade = "São Paulo",
                Bairro = "Centro",
                Rua = "Avenida Principal",
                NResidencia = "123",
                Cep = "01000000",
                Ativo = true
            };

            // Adiciona a pessoa ao contexto
            context.Pessoas.Add(pessoaMaster);
            context.SaveChanges();

            // Cria uma nova instância de Funcionario usando o Pessoa criada
            var funcionarioMaster = new Funcionario
            {
                PessoaId = pessoaMaster.Id,
                Cpf = "12345678901"
            };

            // Adiciona o funcionário ao contexto e salva as alterações
            context.Funcionarios.Add(funcionarioMaster);
            context.SaveChanges();

            var pessoa1 = new Pessoa
            {
                Email = "joao@exemplo.com",
                Nome = "João Silva",
                Senha = "senha123",  // Senha fictícia, considere criptografia
                Uf = "SP",
                Cidade = "São Paulo",
                Bairro = "Jardim Paulista",
                Rua = "Rua das Flores",
                NResidencia = "123",
                Cep = "01001000",
                Ativo = true
            };

            var pessoa2 = new Pessoa
            {
                Email = "maria@exemplo.com",
                Nome = "Maria Santos",
                Senha = "senha123",  // Senha fictícia, considere criptografia
                Uf = "RJ",
                Cidade = "Rio de Janeiro",
                Bairro = "Copacabana",
                Rua = "Avenida Atlântica",
                NResidencia = "456",
                Cep = "22070001",
                Ativo = true
            };

            // Adicionando pessoas ao contexto
            context.Pessoas.Add(pessoa1);
            context.Pessoas.Add(pessoa2);
            context.SaveChanges();

            // Criando registros de clientes associados às pessoas
            var cliente1 = new Cliente
            {
                PessoaId = pessoa1.Id,
                Cnpj = "12345678000101",
                FuncionarioId = funcionarioMaster.Id
            };

            var cliente2 = new Cliente
            {
                PessoaId = pessoa2.Id,
                Cnpj = "98765432000199",
                FuncionarioId = funcionarioMaster.Id
            };

            // Adicionando clientes ao contexto
            context.Clientes.Add(cliente1);
            context.Clientes.Add(cliente2);

            var telefone1 = new Telefone
            {
                PessoaId = pessoa1.Id,
                NTelefone = "997536911"
            };

            var telefone2 = new Telefone
            {
                PessoaId = pessoa2.Id,
                NTelefone = "992454434"
            };
            context.Telefones.Add(telefone1);
            context.Telefones.Add(telefone2);
            context.SaveChanges();
        }
    }
}
