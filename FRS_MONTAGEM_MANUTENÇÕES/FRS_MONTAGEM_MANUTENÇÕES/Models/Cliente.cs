using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Cliente
    {

        #region Getters Setters
        public int Id { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        public string Cnpj { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos


        public void Cadastrar()
        {

        }

        public List<Cliente> BuscarTodos(Context context)
        {
            List<Cliente> cliente = context.Clientes.Include(c => c.Pessoa).ToList();
            return cliente;
        }

        public Cliente BuscarPorId(Context context, int id)
        {
            Cliente cliente = context.Clientes.Where(a => a.Id.Equals(id)).FirstOrDefault();
            return cliente;
        }

        public Cliente BuscarPorIdPessoa(Context context, int id)
        {
            Cliente cliente = context.Clientes.Where(a => a.PessoaId.Equals(id)).FirstOrDefault();
            return cliente;
        }

        public void FormatarCnpj()
        {
            if (!string.IsNullOrEmpty(Cnpj) || Cnpj.Length == 14)
            {
                this.Cnpj = $"{Cnpj.Substring(0, 2)}.{Cnpj.Substring(2, 3)}.{Cnpj.Substring(5, 3)}/{Cnpj.Substring(8, 4)}-{Cnpj.Substring(12, 2)}";
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
