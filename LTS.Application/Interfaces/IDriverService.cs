using System.Collections.Generic;
using System.Threading.Tasks;
using LTS.Application.DTOs;

namespace LTS.Application.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDto>> GetAllAsync();
        Task<DriverDto?> GetByIdAsync(int id);
        Task<DriverDto> CreateAsync(DriverDto driverDto);
        Task<bool> UpdateAsync(int id, DriverDto driverDto);
        Task<bool> DeleteAsync(int id);
    }
}