namespace FRS_Montagens_e_Manutenção.Models
{
    public class Cliente : Pessoa
    {
        //Getters Setters
        public string Cnpj {  get; set; }
        public List<Pedido> Pedido {  get; set; }

        //Construtores


        //Metodos
    }
}
