using FRS_MONTAGEM_MANUTENÇÕES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.ComponentModel.DataAnnotations;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Pessoa
    {
        #region Atributos

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string NResidencia { get; set; }
        public string Cep { get; set; }
        public bool Ativo { get; set; } = true;
        public virtual List<Cliente> Clientes { get; set; }

        // Relacionamento com Funcionario
        public virtual List<Funcionario> Funcionarios { get; set; }

        // Relacionamento com Telefone
        public virtual List<Telefone> Telefones { get; set; } = new List<Telefone>();
        #endregion

        #region Construtores

        #endregion

        #region Metodos

        private void addPessoasFuncionario()
        {

        }

        public List<Pessoa> BuscarPessoas(Context _context)
        {
             List<Pessoa> pessoas = _context.Pessoas.ToList();
            return pessoas;
        }

        public Pessoa BuscarPorId(Context _context, int id)
        {
            var pessoa = _context.Pessoas.Where(a => a.Id == id).FirstOrDefault();
            return pessoa;
        }

        public void Logar(Pessoa pessoa, Context _context)
        {
//_context.Pessoas.AsQueryable().Where(a => a.Nome == pessoa.Nome && a.Senha == pessoa.Senha).FirstOrDefault();
            
            if (pessoa.Nome == "admin123" && pessoa.Senha == "admin123")
            {
               
            }

        }
        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        #endregion

    }
}
