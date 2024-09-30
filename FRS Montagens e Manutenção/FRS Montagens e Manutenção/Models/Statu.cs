namespace FRS_Montagens_e_Manutenção.Models
{
    public class Statu
    {
        //Getters Setters
        public string Id {  get; set; }
        public string Nome { get; set; }
        public virtual List<Topico> Topico { get; set; }
        public virtual List<Pedido> PedidoStatu { get; set; }
        
        //Construtores


        //Metodos
    }
}
