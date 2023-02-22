using AutoMapper;
using DepartamentosMunicipiosMVC.Data;
using DepartamentosMunicipiosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosMVC.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DepartamentoRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<int> Count()
        {
            return await _context.Departamentos.CountAsync();
        }

        public async Task<int> Delete(int id)
        {
            var departamento = await FindById(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
            }

            return await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return (_context.Departamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<Departamento> FindById(int? id)
        {
            return await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Departamento>> GetAll()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<int> Insert(Departamento departamento)
        {
            _context.Add(departamento);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Departamento departamento)
        {
            _context.Update(departamento);
            return await _context.SaveChangesAsync();
        }
    }
}
