﻿using FRS_MONTAGEM_MANUTENÇÕES.Models.ViewModels;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Security.Claims;

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
                int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                Funcionario funcionario = new Funcionario().BuscarPorIdPessoa(_context, id);

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
                cliente.FuncionarioId = funcionario.Id;
                cliente.Salvar(_context);

                foreach (var telefoneViewModel in clienteNovo.Telefones)
                {
                    var telefone = new Telefone
                    {
                        PessoaId = pessoa.Id,
                        NTelefone = telefoneViewModel.NTelefone,
                        Pessoa = pessoa,
                    };
                    telefone.Salvar(_context);
                }
                return RedirectToAction("Index", "PerfilFuncionario", new { id = funcionario.Id });
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
