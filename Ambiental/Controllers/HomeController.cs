using Ambiental.Data.Context;
using Ambiental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ambiental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            // var lista = _context.QualidadeArModels.ToList();

            //var qualidadeArModels = new QualidadeArModel
            //{
            //    Localizacao = "Pernanbuco",
            //    IndiceQualidade = "Baixa",
            //    DataLeitura = 2024
            //};

            //_context.QualidadeArModels.Add(qualidadeArModels);
            //_context.SaveChanges();


            return View();
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
