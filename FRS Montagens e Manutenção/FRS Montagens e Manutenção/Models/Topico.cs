namespace FRS_Montagens_e_Manutenção.Models
{
    public class Topico
    {
        //Getters Setters
        private string Id {  get; set; }
        private Statu Status { get; set; }
        private DateTime DataInicio { get; set; }
        private DateTime DataTermino { get; set; }
        private string Descricao { get; set; }
        private List<Topico> FkIdTopico {  get; set; }
        private Pedido Pedido { get; set; }
        
        //Construtores


        //Metodos
    }
}
