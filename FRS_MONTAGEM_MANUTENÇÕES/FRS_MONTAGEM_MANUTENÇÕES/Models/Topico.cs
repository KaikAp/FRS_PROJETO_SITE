using Microsoft.EntityFrameworkCore;
using Repository;

namespace FRS_Montagens_e_Manutenção.Models
{
    public class Topico
    {
        #region Getters Setters
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual Pedido Pedido { get; set; }
        public int PedidoId { get; set; }

        public virtual List<SubTopico> SubTopicos { get; set; }
        #endregion

        #region Construtores
        #endregion

        #region Metodos
        public List<Topico> BusccarPorIdPedido(Context context, int id)
        {
            List<Topico> topicos = context.Topicos.Where(a => a.PedidoId == id).ToList();
            return topicos;
        }

        public Topico BuscarPorId(Context context, int Id)
        {
            Topico topico = context.Topicos.Where(a => a.Id == Id).FirstOrDefault();
            return topico;
        }

        public void Alterar(Context context)
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
        #endregion
    }
}
