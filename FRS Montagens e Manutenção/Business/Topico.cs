using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Topico
    {
        private string Id {  get; set; }
        private Status Status { get; set; }
        private DateTime DataInicio { get; set; }
        private DateTime DataTermino { get; set; }
        private string Descricao { get; set; }
        private List<Topico> FkIdTopico {  get; set; }
        private Pedido Pedido { get; set; }
    }
}
