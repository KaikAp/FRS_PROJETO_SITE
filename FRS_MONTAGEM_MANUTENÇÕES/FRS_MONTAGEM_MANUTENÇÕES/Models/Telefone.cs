using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Telefone
    {
        #region Getters Setters
        public int PessoaId { get; set; }
        public string NTelefone { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        public void Salvar(Context context)
        {
            context.Telefones.Add(this);
            context.SaveChanges();
        }
        public List<Telefone> BuscarPorIdPessoa (Context context, int pessoaId)
        {
            var telefones =  context.Telefones.Where(a => a.PessoaId == pessoaId).ToList();
            return telefones;
        }
        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
        #endregion
    }
}
