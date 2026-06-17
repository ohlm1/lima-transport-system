using LTS.Domain.Entities;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface IDriverRepository
    {
        Task AddAsync(Driver driver);
        Task<Driver?> GetByIdAsync(int id);
        Task<Driver?> GetByCpfAsync(string cpf);
    }
}