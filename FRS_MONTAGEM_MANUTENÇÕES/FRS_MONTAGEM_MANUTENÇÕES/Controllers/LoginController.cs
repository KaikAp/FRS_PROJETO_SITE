using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nome, string senha)
        {
            var authSchema = CookieAuthenticationDefaults.AuthenticationScheme;

            if (_context.Clientes.Any(c => c.Cnpj == nome) && _context.Pessoas.Any(c => c.Senha == senha))
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Cnpj == nome);
                var pessoa = _context.Pessoas.FirstOrDefault(c => c.Id == cliente.PessoaId);
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, pessoa.Id.ToString()),
                    new Claim(ClaimTypes.Name, pessoa.Nome)
                };
                var identity = new ClaimsIdentity(claims, authSchema);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(authSchema, principal);

                return View("~/Views/PerfilCliente/Index.cshtml");
            }
            else if (_context.Funcionarios.Any(c => c.Cpf == nome) && _context.Pessoas.Any(c => c.Senha == senha))
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(c => c.Cpf == nome);
                return RedirectToAction("Index", "PerfilFuncionario");
            }
            else
            {
                ModelState.AddModelError("", "Nome de usuário ou senha inválidos");
                return View("Index");
            }
        }
    }
}
