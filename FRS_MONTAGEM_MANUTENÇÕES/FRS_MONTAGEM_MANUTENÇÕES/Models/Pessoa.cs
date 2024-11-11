using FRS_MONTAGEM_MANUTENÇÕES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.ComponentModel.DataAnnotations;
using NuGet.Protocol.Plugins;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Pessoa
    {
        #region Atributos

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
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

        public Dictionary<string, string> Salvar(Context context)
        {
            Dictionary<string, string> erros =
                new Dictionary<string, string>();

            if (Nome.Length > 50)
            {
                erros.Add("Nome", "Este campo deve possuir no máximo 50 caracteres");
            }
            if (Email.Length > 50)
            {
                erros.Add("Email", "Este campo deve possuir no máximo 50 caracteres");
            }
            if (Senha.Length > 100)
            {
                erros.Add("Senha", "Este campo deve possuir no máximo 100 caracteres");
            }
            if (Cidade.Length > 30)
            {
                erros.Add("Cidade", "Este campo deve possuir no máximo 30 caracteres");
            }
            if (Bairro.Length > 30)
            {
                erros.Add("Bairro", "Este campo deve possuir no máximo 30 caracteres");
            }
            if (Rua.Length > 100)
            {
                erros.Add("Rua", "Este campo deve possuir no máximo 100 caracteres");
            }
            if (NResidencia.Length > 5)
            {
                erros.Add("NResidencia", "Este campo deve possuir no máximo 5 caracteres");
            }
            if (Cep.Length > 8)
            {
                erros.Add("Cep", "Este campo deve possuir no máximo 8 caracteres");
            }

            if (erros.Count == 0)
            {
                context.Pessoas.Add(this);
                context.SaveChanges();
            }

            return erros;
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
