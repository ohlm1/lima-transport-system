using LTS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Application.Services
{
    public interface IDriverService
    {
        Task RegisterAsync(DriverDto driverDto);
        Task<DriverDto?> GetByIdAsync(int id);
        Task<IEnumerable<DriverDto>> GetallAsync();
    
    }

}