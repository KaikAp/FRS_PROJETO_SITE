namespace FRS_Montagens_e_Manutenção.Models
{
    public class Funcionario : Pessoa
    {
        #region Getters Setters
        public virtual Pessoa IdPessoa { get; set; }
        public string Cpf {  get; set; }
        public bool Gerente {  get; set; }
        public List<Pedido> PedidoFuncionario {  get; set; }
        public virtual List<Cliente> ClienteFuncionario { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        #endregion
    }
}
