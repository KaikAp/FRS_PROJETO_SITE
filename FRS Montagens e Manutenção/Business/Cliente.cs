using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Cliente : Pessoa
    {
        private string Cnpj {  get; set; }
        private List<Pedido> Pedido {  get; set; }

    }
}
