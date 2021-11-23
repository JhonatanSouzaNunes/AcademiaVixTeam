using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VixTeamAula.Models;

namespace VixTeamAula.Controllers
{
    public class EmpresaController : Controller
    {

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(new EmpresaModel()
            {
                codigo = 1,
                NomeEmpresa = "Primeira empresa",
                NomeFantasia = "PEM",
                CNPJ = "88.777.666/0005-43",

            });
        }
      
    }
    
}
