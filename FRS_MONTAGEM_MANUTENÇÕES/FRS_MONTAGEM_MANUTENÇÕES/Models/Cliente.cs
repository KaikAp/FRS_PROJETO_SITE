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
        #endregion
    }
}
