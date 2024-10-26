namespace FRS_Montagens_e_Manutenção.Models
{
    public class Statu
    {
        #region Getters Setters
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Topico> Topicos { get; set; }
        public virtual List<Pedido> PedidoStatu { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        #endregion
    }
}
