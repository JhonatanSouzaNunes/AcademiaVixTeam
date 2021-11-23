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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("codigo,NomeEmpresa,NomeFantasia,CNPJ")] EmpresaModel empresaModel )
        {
            try
            {
                return View("Index");
            }
            catch
            {
                return View();
            }
        }


    }
    
}
