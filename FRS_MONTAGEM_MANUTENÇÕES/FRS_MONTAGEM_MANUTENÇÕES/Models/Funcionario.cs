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


        private void addFuncionario(Funcionario funcionario, Context _context)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
        }
        #endregion
    }
}
