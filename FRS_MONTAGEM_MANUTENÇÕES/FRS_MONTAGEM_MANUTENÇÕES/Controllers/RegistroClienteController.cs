using FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FRS_MONTAGEM_MANUTENÇÕES.Controllers
{
    public class RegistroClienteController : Controller
    {
        private Context _context;

        public RegistroClienteController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaClienteTelefone clienteNovo)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = clienteNovo.Nome;
                pessoa.Email = clienteNovo.Email;
                pessoa.Rua = clienteNovo.Rua;
                pessoa.NResidencia = clienteNovo.NResidencia;
                pessoa.Bairro = clienteNovo.Bairro;
                pessoa.Cep = clienteNovo.Cep;
                pessoa.Cidade = clienteNovo.Cidade;
                pessoa.Uf = clienteNovo.Uf;
                pessoa.Senha = clienteNovo.Senha;

                pessoa.Salvar(_context);

                Cliente cliente = new Cliente();
                cliente.Cnpj = clienteNovo.Cnpj;
                cliente.PessoaId = pessoa.Id;
                cliente.Salvar(_context);

                foreach (var telefoneViewModel in clienteNovo.Telefones)
                {
                    int i = 0;
                    var telefone = new Telefone
                    {
                        PessoaId = pessoa.Id,
                        NTelefone = clienteNovo.Telefones[i].NTelefone,
                    };
                    telefone.Salvar(_context);
                    i++;
                }

                //Salvo com sucesso, sem erros
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
