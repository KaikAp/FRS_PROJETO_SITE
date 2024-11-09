namespace FRS_Montagens_e_Manutenção.Models
{
    public class Topico
    {
        #region Getters Setters
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual Pedido Pedido { get; set; }
        public int PedidoId { get; set; }

        public virtual List<SubTopico> SubTopicos { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        #endregion
    }
}
