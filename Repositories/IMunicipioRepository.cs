using DepartamentosMunicipiosMVC.Models;

namespace DepartamentosMunicipiosMVC.Repositories
{
    public interface IMunicipioRepository
    {
        Task<List<Municipio>> GetAll();
        Task<Municipio> FindById(int? id);
        Task<int> Insert(Municipio municipio);
        Task<int> Update(Municipio municipio);
        Task<int> Delete(int id);
        Task<int> Count();

        bool Exists(int id);
    }
}
