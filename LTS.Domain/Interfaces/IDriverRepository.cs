using LTS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface IDriverRepository
    {
        Task AddAsync(Driver driver);
        Task<Driver?> GetByIdAsync(int id);
        Task<Driver?> GetByCpfAsync(string cpf);
        Task<IEnumerable<Driver>> GetAllAsync(); 
        Task UpdateAsync(Driver driver);        
    }
}