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
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("codigo,NomeEmpresa,NomeFantasia,CNPJ")] EmpresaModel empresaModel )
        {
            try
            {
                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View();
            }
        }


    }
    
}
