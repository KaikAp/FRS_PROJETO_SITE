namespace FRS_Montagens_e_Manutenção.Models
{
    public class Pedido
    {
        //Getters Setters
        private int Id {  get; set; }
        private string Descrição { get; set; }
        private DateTime DataInicio { get; set; }
        private DateTime DataTermino { get; set; }
        private int Duracao { get; set; }
        private Funcionario Funcionario { get; set; }
        private Cliente Cliente { get; set; }
        private Status Status { get; set; }
        private List<Topico> Topico { get; set; }

        //Construtores


        //Metodos
    }
}
