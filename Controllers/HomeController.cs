using GrupoClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GrupoClientes.Data;
using Microsoft.EntityFrameworkCore;

namespace GrupoClientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _context;

        public HomeController(ILogger<HomeController> logger, Contexto context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(string nome, string senha)
        {
            
            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(senha))
            {
                ViewBag.Erro = "Por favor, informe o nome e a senha";
                return View();
            }
            else
            {
                var usuario = await _context.Usuario.AnyAsync(u => u.Nome
                    == nome && u.Senha == senha);
                if (!usuario)
                {
                    ViewBag.Erro = "Usuário ou senha inválidos";
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Menu");
                }
            }              
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