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
            try
            {
                var authSchema = CookieAuthenticationDefaults.AuthenticationScheme;
                Pessoa pessoa = new Pessoa().Logar(_context, nome, senha);
                Cliente cliente = new Cliente().BuscarPorIdPessoa(_context, pessoa.Id);
                Funcionario funcionario = new Funcionario().BuscarPorIdPessoa(_context, pessoa.Id);

                if (cliente is not null)
                {
                    var claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, pessoa.Id.ToString()),
                    new Claim(ClaimTypes.Name, pessoa.Nome)
                };
                    var identity = new ClaimsIdentity(claims, authSchema);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(4),
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(authSchema, principal, authProperties);

                    return RedirectToAction("Index", "PerfilCliente");
                }
                else if (funcionario is not null)
                {
                    var claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, pessoa.Id.ToString()),
                    new Claim(ClaimTypes.Name, pessoa.Nome),
                    new Claim(ClaimTypes.Email, pessoa.Email)
                };
                    var identity = new ClaimsIdentity(claims, authSchema);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(4),
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(authSchema, principal, authProperties);

                    return RedirectToAction("Index", "PerfilFuncionario");
                }
                else
                {
                    ModelState.AddModelError("", "Nome de usuário ou senha inválidos");
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        public IActionResult page()
        {
            var idLogado = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(c => c.Id == idLogado);
            if (_context.Clientes.Any(c => c.PessoaId == idLogado)){
                
                return View("~/Views/PerfilCliente/Index.cshtml",pessoa);
            }
            else
            {
                return View("~/Views/PerfilFuncionario/Index.cshtml", pessoa);
            }
        }

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


    }
}
