namespace FRS_Montagens_e_Manutenção.Models
{
    public class Topico
    {
        #region Getters Setters
        public int Id { get; set; }
        public Statu Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Descricao { get; set; }
        public List<Topico> FkIdTopico { get; set; }
        public Pedido Pedido { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        #endregion
    }
}
