using FRS_MONTAGEM_MANUTENÇÕES.Models;
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
        public bool? Ativo { get; set; }
        public virtual List<Cliente> Clientes { get; set; }

        // Relacionamento com Funcionario
        public virtual List<Funcionario> Funcionarios { get; set; }

        // Relacionamento com Telefone
        public virtual List<Telefone> Telefones { get; set; }
        #endregion

        #region Construtores

        #endregion

        #region Metodos

        private void addPessoasFuncionario()
        {

        }

        public void getPessoa(Context _context)
        {
            List<Pessoa> pessoas = _context.Pessoas.ToList();
        }

        public Pessoa BuscarPorIdCliente(Context _context, int id)
        {
            var pessoa = _context.Pessoas.Where(a => a.Id == id).FirstOrDefault();
            return pessoa;
        }
        public void Logar(Pessoa pessoa, Context _context)
        {
            var pessoas = _context.Pessoas.AsQueryable().Where(a => a.Nome == pessoa.Nome && a.Senha == pessoa.Senha).FirstOrDefault();
            if (pessoas != null)
            {
                
            }

        }

        #endregion

    }
}
