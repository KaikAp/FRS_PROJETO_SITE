namespace FRS_Montagens_e_Manutenção.Models
{
    public class Cliente : Pessoa
    {
        //Getters Setters
        public virtual Pessoa IdPessoa { get; set; }
        public virtual Funcionario IdFuncionario {  get; set; } 
        public string Cnpj {  get; set; }
        public List<Pedido> PedidoCliente {  get; set; }
        public List<Telefone> TelefoneCliente { get; set; }

        //Construtores


        //Metodos
    }
}
