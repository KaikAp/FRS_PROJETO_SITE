namespace FRS_Montagens_e_Manutenção.Models
{
    public class Pedido
    {
        //Getters Setters
        public int Id {  get; set; }
        public string Descrição { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int Duracao { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Statu Status { get; set; }
        public List<Topico> Topico { get; set; }

        //Construtores


        //Metodos
    }
}
