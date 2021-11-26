using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VixTeamAula.Data;
using VixTeamAula.Models;
using VixTeamAula.Business;


namespace VixTeamAula.Controllers
{
    public class PessoaModelsController : Controller
    {
        private readonly VixTeamAulaContext _context;

        public PessoaModelsController(VixTeamAulaContext context)
        {
            _context = context;
        }

        // GET: PessoaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaModel.ToListAsync());
        }

        // GET: PessoaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return View(pessoaModel);
        }

        // GET: PessoaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo,NomePessoa,Email,DataNascimento,QtdFilhos,Salario,Situacao")] PessoaModel pessoaModel)
        {
            
            var email = _context.PessoaModel.Where(x => x.Email.Equals(pessoaModel.Email));
            if (email.Count() > 0)
            {
                ModelState.AddModelError("Regra de Negócio", "Email já está cadastrado");
                return View("Create");
            }
            if(pessoaModel.Salario < 1200 || pessoaModel.Salario > 13000)
            {
                ModelState.AddModelError("Regra de Negócio", "Salário não pode ser inferior a R$1.200 ou maior que R$ 13.000");
                return View("Create");
            }


            pessoaModel.Situacao = true;
                _context.Add(pessoaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           // return View(pessoaModel);
        }

        // GET: PessoaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

          

            return View(pessoaModel);
        }

        // POST: PessoaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo,NomePessoa,Email,DataNascimento,QtdFilhos,Salario,Situacao")] PessoaModel pessoaModel)
        {
            if (id != pessoaModel.codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (pessoaModel.QtdFilhos < 0)
                    {
                        ModelState.AddModelError("Regra de Negócio", "Quantidade de filhos nao pode ser menor que '0'");
                        return View(pessoaModel);
                    }

                    if (pessoaModel.DataNascimento < new DateTime(1900, 1, 1)) {

                        ModelState.AddModelError("Regra de Negócio", "Data de nascimento não pode ser inferior a '1/1/1900'");
                        return View(pessoaModel);
                    }

                    var email = _context.PessoaModel.Where(x => x.Email.Equals(pessoaModel.Email));
                    if(email.Count() > 0)
                    {

                        ModelState.AddModelError("Regra de Negócio", "Email já está cadastrado");
                        return View(pessoaModel);
                    }

                    _context.Update(pessoaModel);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaModelExists(pessoaModel.codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaModel);
        }

        // GET: PessoaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }
           
            return View(pessoaModel);
        }

        // POST: PessoaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaModel = await _context.PessoaModel.FindAsync(id);

            if (pessoaModel.Situacao == true)
            {
                ModelState.AddModelError("Regra de Negócio", "Não é possivel deletar quando situação estiver ativa");
            }
            else
            {
            _context.PessoaModel.Remove(pessoaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool PessoaModelExists(int id)
        {
            return _context.PessoaModel.Any(e => e.codigo == id);
        }


        // ALTERAR STATUS NO INDEX

        public async Task<IActionResult> AlterarStatus(int? id)
        {
            try
            {
                var pessoaModel = await _context.PessoaModel.FindAsync(id);
                if (pessoaModel.Situacao == true)
                {
                    pessoaModel.Situacao = false;
                }
                else
                {
                    pessoaModel.Situacao = true;
                }
                _context.Update(pessoaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Index));
            }
         }
    }
}
