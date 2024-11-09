namespace FRS_Montagens_e_Manutenção.Models
{
    public class SubTopico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual Topico Topico { get; set; }
        public int TopicoId { get; set; }
    }
}
