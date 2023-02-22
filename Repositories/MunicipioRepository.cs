using AutoMapper;
using DepartamentosMunicipiosMVC.Data;
using DepartamentosMunicipiosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosMVC.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MunicipioRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Count()
        {
            return await _context.Municipios.CountAsync();
        }

        public async Task<int> Delete(int id)
        {
            var municipio = await FindById(id);
            if (municipio != null)
            {
                _context.Municipios.Remove(municipio);
            }
            return await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return (_context.Departamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<Municipio> FindById(int? id)
        {
            return await _context.Municipios.FindAsync(id);
        }

        public Task<List<Municipio>> GetAll()
        {
            return _context.Municipios.ToListAsync();
        }

        public async Task<int> Insert(Municipio municipio)
        {
            _context.Add(municipio);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Municipio municipio)
        {
            _context.Update(municipio);
            return await _context.SaveChangesAsync();
        }
    }
}
