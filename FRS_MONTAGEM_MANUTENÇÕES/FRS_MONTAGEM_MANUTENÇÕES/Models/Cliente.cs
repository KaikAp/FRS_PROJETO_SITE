using Repository;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Cliente : Pessoa
    {

        #region Getters Setters
        public virtual Pessoa IdPessoa { get; set; }
        public virtual Funcionario IdFuncionario { get; set; }
        public string Cnpj { get; set; }
        public List<Pedido> PedidoCliente { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos


        public void Cadastrar()
        {

        }

        public List<Cliente> BuscarTodos(Context context)
        {
            List<Cliente> cliente = context.clientes.ToList();
            return cliente;
        }
        #endregion
    }
}
