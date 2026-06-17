using LTS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllAsync();
        Task<VehicleDto?> GetByIdAsync(int id);

        Task AddAsync(VehicleDto vehicleDto);
    }
}