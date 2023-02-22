using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DepartamentosMunicipiosMVC.Data;
using DepartamentosMunicipiosMVC.Models;
using DepartamentosMunicipiosMVC.Repositories;
using AutoMapper;

namespace DepartamentosMunicipiosMVC.Controllers
{
    public class MunicipiosController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly MunicipioRepository _repository;

        public MunicipiosController(ApplicationDbContext context, IMapper mapper)
        {
            _repository = new MunicipioRepository(context, mapper);
        }

        // GET: Municipios
        public async Task<IActionResult> Index()
        {
            var municipios = await _repository.GetAll();
            return View(municipios);
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _repository.FindById(id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_repository.GetDepartamentosDbSet(), "Id", "Nombre");
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CNRCompleto,Latitud,Longitud,DepartamentoId")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                await _repository.Insert(municipio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_repository.GetDepartamentosDbSet(), "Id", "Nombre", municipio.DepartamentoId);
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _repository.FindById(id);
            if (municipio == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_repository.GetDepartamentosDbSet(), "Id", "Nombre", municipio.DepartamentoId); ;
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CNRCompleto,Latitud,Longitud,DepartamentoId")] Municipio municipio)
        {
            if (id != municipio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(municipio);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.Id))
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
            ViewData["DepartamentoId"] = new SelectList(_repository.GetDepartamentosDbSet(), "Id", "Nombre", municipio.DepartamentoId);
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _repository.FindById(id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var municipio = await _repository.FindById(id);
            if (municipio != null)
            {
                await _repository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
