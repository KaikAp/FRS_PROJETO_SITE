using FRS_Montagens_e_Manutenção.Models;

namespace FRS_MONTAGEM_MANUTENÇÕES.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Pessoa> cargopessoa { get; set; }
    }
}
