using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Academia.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AcademiaContext _repo { get; }

        public HomeController(ILogger<HomeController> logger, AcademiaContext repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repo.Aluno.ToListAsync());
        }

        public async Task<IActionResult> PesquisaAluno(string pesquisaNomeAluno)
        {
            return View("Index", await _repo.Aluno.Where(a => a.Nome.Contains(pesquisaNomeAluno)).ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
