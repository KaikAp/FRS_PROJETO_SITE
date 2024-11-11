using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Security.Claims;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    [Authorize]
    public class PerfilClienteController : Controller
    {
        private readonly Context _context;
            public IActionResult Index(Pessoa pessoa)
            {
            // a pessoa que vem já vem o usuario que você precisa caso queira tive que fazer do jeito porco pq não tava funfando
            //var idLogado = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); //aqui você consegue pegar o id se quiser
            return View("index", pessoa);
            }
    }
}
