using Microsoft.EntityFrameworkCore;
using Repository;

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

        public List<SubTopico> BusccarPorIdTopico(Context context, int id)
        {
            List<SubTopico> subTopico = context.SubTopicos.Where(a => a.TopicoId == id).ToList();
            return subTopico;
        }

        public SubTopico BuscarPorId(Context context, int id)
        {
            SubTopico subTopico = context.SubTopicos.Where(a => a.Id.Equals(id)).FirstOrDefault();
            return subTopico;
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remover(Context context)
        {
            context.SubTopicos.Remove(this);
            context.SaveChanges();
        }
    }
}
