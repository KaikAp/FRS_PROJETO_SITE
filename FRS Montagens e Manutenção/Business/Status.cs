using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Status
    {
        private string Id {  get; set; }
        private string Nome { get; set; }
        private List<Topico> Topico { get; set; }
    }
}
