using System.Collections.Generic;
using System.Threading.Tasks;
using LTS.Domain.Entities;

namespace LTS.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver?> GetByIdAsync(int id);

        Task<Driver?> GetByCpfAsync(string cpf);

        Task<IEnumerable<Driver>> GetAllAsync();

        Task AddAsync(Driver driver);

        Task UpdateAsync(Driver driver);
    }
}