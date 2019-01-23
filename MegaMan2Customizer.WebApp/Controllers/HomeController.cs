﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MegaMan2Customizer.WebApp.Models;
using Microsoft.AspNetCore.Http;
using MegaMan2Customizer.Core;

namespace MegaMan2Customizer.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() => View();

        [HttpGet("randomizer")]
        public IActionResult Randomizer() => View();

        [HttpGet("about")]
        public IActionResult About() => View();

        [HttpGet("privacy")]
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => 
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
