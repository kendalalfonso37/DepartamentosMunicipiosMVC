using AutoMapper;
using DepartamentosMunicipiosMVC.Data;
using DepartamentosMunicipiosMVC.Models;

namespace DepartamentosMunicipiosMVC.Repositories
{
    public class MunicipioRepository : IGenericRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MunicipioRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Departamento> FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Departamento>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Departamento departamento)
        {
            throw new NotImplementedException();
        }
    }
}
