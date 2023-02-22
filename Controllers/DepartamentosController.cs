using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartamentosMunicipiosMVC.Data;
using DepartamentosMunicipiosMVC.Models;
using AutoMapper;
using DepartamentosMunicipiosMVC.Repositories;

namespace DepartamentosMunicipiosMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentoRepository _repository;
        public DepartamentosController(ApplicationDbContext context, IMapper mapper)
        {
            _repository = new DepartamentoRepository(context, mapper);
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            var departamentos = await _repository.GetAll();
            return View(departamentos);
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _repository.FindById(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CNRCompleto,Latitud,Longitud")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _repository.FindById(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CNRCompleto,Latitud,Longitud")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(departamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id))
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
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _repository.FindById(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var departamento = await _repository.FindById(id);
            if (departamento != null)
            {
                await _repository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
