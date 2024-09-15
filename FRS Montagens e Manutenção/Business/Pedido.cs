using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pedido
    {
        private int Id {  get; set; }
        private string Descrição { get; set; }
        private DateTime DataInicio { get; set; }
        private DateTime DataTermino { get; set; }
        private int Duracao { get; set; }
        private Funcionario Funcionario { get; set; }
        private Cliente Cliente { get; set; }
    }
}
