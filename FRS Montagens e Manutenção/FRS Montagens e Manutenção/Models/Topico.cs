namespace FRS_Montagens_e_Manutenção.Models
{
    public class Topico
    {
        //Getters Setters
        public string Id {  get; set; }
        public Statu Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Descricao { get; set; }
        public List<Topico> FkIdTopico {  get; set; }
        public Pedido Pedido { get; set; }
        
        //Construtores


        //Metodos
    }
}
