namespace FRS_Montagens_e_Manutenção.Models
{
    public class Funcionario : Pessoa
    {
        //Getters Setters
        private string Cpf {  get; set; }
        private bool Gerente {  get; set; }
        private List<Pedido> Pedido {  get; set; }

        //Construtores


        //Metodos
    }
}
