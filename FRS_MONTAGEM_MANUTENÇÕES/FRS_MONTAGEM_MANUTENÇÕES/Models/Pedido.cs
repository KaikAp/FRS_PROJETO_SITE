namespace FRS_Montagens_e_Manutenção.Models
{
    public class Pedido
    {
        #region Getters Setters
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public virtual List<Topico> Topicos { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        public void CadastrarPedidoInteiro()
        {

        }
        #endregion
    }
}
