using LTS.Application.DTOs; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Application.Services
{
    public interface IVehicleService
    {
        Task RegisterAsync(VehicleDto vehicleDto);
        Task<VehicleDto?> GetByIdAsync(int id);
        Task<IEnumerable<VehicleDto>> GetAllAsync();
    }
}