using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Funcionario : Pessoa
    {
        private string Cpf {  get; set; }
        private bool Gerente {  get; set; }
        private List<Pedido> Pedido {  get; set; }

    }
}
