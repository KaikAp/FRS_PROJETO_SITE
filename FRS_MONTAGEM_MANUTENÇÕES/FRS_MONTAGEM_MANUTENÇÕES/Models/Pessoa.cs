using FRS_MONTAGEM_MANUTENÇÕES.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public void Salvar(Context context)
        {
            context.Pessoas.Add(this);
            context.SaveChanges();
       
        }

        public Pessoa BuscarPorId(Context context, int id)
        {
            var pessoa = context.Pessoas.Where(a => a.Id == id).FirstOrDefault();
            return pessoa;
        }

        public Pessoa Logar(Context context, string email, string senha)
        {
            var pessoa = context.Pessoas.Where(a => a.Email == email).FirstOrDefault();

            if (pessoa.Senha == senha && pessoa.Ativo == true)
            {
                return pessoa;
            }

            return null;
        }
        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        #endregion

    }
}
