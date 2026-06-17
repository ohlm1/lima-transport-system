using LTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces 
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task<Vehicle?> GetByLicensePlateAsync(string licensePlate);
    }
}