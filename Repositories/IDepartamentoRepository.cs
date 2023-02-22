using DepartamentosMunicipiosMVC.Models;

namespace DepartamentosMunicipiosMVC.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<List<Departamento>> GetAll();
        Task<Departamento> FindById(int? id);
        Task<int> Insert(Departamento departamento);
        Task<int> Update(Departamento departamento);
        Task<int> Delete(int id);
        Task<int> Count();

        bool Exists(int id);
    }
}
