using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VixTeamAula.Models;

namespace VixTeamAula.Controllers
{
    public class EmpresaController :Controller
    {

            private readonly ILogger<EmpresaController> _logger;

            public EmpresaController(ILogger<EmpresaController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
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
