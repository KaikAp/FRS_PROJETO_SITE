namespace FRS_Montagens_e_Manutenção.Models
{
    public class Telefone
    {
        #region Getters Setters
        public int PessoaId { get; set; }
        public string NTelefone { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        #endregion
    }
}
