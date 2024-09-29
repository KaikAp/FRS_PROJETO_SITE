namespace FRS_Montagens_e_Manutenção.Models
{
    public class Funcionario : Pessoa
    {
        //Getters Setters
        public virtual Pessoa IdPessoa { get; set; }
        public string Cpf {  get; set; }
        public bool Gerente {  get; set; }
        public List<Pedido> Pedido {  get; set; }
        public virtual List<Cliente> Cliente { get; set; }

        //Construtores


        //Metodos
    }
}
