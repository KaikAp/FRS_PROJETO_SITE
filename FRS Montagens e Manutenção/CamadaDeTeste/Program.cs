using FRS_Montagens_e_Manutenção.Models;
using Microsoft.EntityFrameworkCore;
using Repository.EntityFramework;

public class Program
{
    static void Main(string[] args)
    {
        bool Continua = true;

        while (Continua == true)
        {
            Telefone telefone = new Telefone();
            telefone.Numero = "1794398483";
            DbContextOptionsBuilder<Context> optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=Frs;trusted_Connection=true;encrypt=false");
            Context context = new Context(optionsBuilder.Options);
            context.Database.EnsureCreated();
            Console.Clear();
            Console.WriteLine("1 - Adicionar novo usuario \n" +
                              "2 - Remover um usuario \n" +
                              "3 - alterar um usuario \n" +
                              "4 - Mostrar todos os usuarios \n" +
                              "5 - Fechar");
            string Escolha = Console.ReadLine();


            if (Escolha == "1")
            {
                Console.WriteLine("Digite o login");
                string Login = Console.ReadLine();
                Console.WriteLine("Digite o senha");
                string Senha = Console.ReadLine();
                Console.WriteLine("Digite o nome");
                string Nome = Console.ReadLine();
                Console.WriteLine("Digite o email");
                string Email = Console.ReadLine();
                Console.WriteLine("Digite o data de nascimento");
                DateTime dtNascimento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Digite o uf");
                char Uf = char.Parse(Console.ReadLine());
                Console.WriteLine("Digite o cidade");
                string Cidade = Console.ReadLine();
                Console.WriteLine("Digite o bairro");
                string Bairro = Console.ReadLine();
                Console.WriteLine("Digite o rua");
                string Rua = Console.ReadLine();
                Console.WriteLine("Digite o nresidencia");
                int nresidencia = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o cep");
                string cep = Console.ReadLine();
                Console.WriteLine("Digite o ativo");
                bool ativo = bool.Parse(Console.ReadLine());
                Pessoa cliente = new Cliente();
                cliente.Login = Login.ToString();
                cliente.Senha = Senha.ToString();
                cliente.Nome = Nome.ToString();
                cliente.Email = Email.ToString();
                cliente.DataNascimento = dtNascimento;
                cliente.Uf = Uf;
                cliente.Cidade = Cidade.ToString();
                cliente.Bairro = Bairro.ToString();
                cliente.Rua = Rua.ToString();
                cliente.NResidencia = nresidencia.ToString();
                cliente.Cep = cep.ToString();
                cliente.Ativo = ativo;
                cliente.DataCadastro = DateTime.Now;
                context.Add(cliente);
                context.SaveChanges();
            }
            else if (Escolha == "2")
            {

            }
            else if (Escolha == "3")
            {

            }
            else if (Escolha == "4")
            {

            }
            else if (Escolha == "5")
            {
                Continua = false;
            }
        }
    }
}