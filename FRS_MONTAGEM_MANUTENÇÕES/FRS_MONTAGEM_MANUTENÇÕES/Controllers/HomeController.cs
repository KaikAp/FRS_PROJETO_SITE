﻿using FRS_Montagens_e_Manutenção.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FRS_Montagens_e_Manutenção.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
