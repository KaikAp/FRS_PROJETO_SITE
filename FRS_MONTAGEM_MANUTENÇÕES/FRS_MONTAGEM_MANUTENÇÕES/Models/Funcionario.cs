using Repository;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Funcionario
    {
        #region Getters Setters
        public int Id { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        public string Cpf { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos


        public Funcionario BuscarPorIdPessoa(Context context, int id)
        {
            var funcionario = context.Funcionarios.Where(a => a.Id == id).FirstOrDefault();
            return funcionario;
        }        
        #endregion
    }
}
