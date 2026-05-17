using System.Collections.Generic;
using System.Threading.Tasks;
using LTS.Domain.Entities;

namespace LTS.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetByIdAsync(int id);

        Task<Vehicle?> GetByLicensePlateAsync(string licensePlate);

        Task<IEnumerable<Vehicle>> GetAllAsync();

        Task AddAsync(Vehicle vehicle);

        Task UpdateAsync(Vehicle vehicle);
    }
}