using LTS.Application.DTOs;
using LTS.Infrastructure.Data.Repositories;
using LTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTS.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly DriverRepository _driverRepository;

        public DriverService(DriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task RegisterAsync(DriverDto driverDto)
        {
            if (string.IsNullOrWhiteSpace(driverDto.Name))
                throw new ArgumentException("O nome do motorista é obrigatório.");

            if (string.IsNullOrWhiteSpace(driverDto.Cpf) || driverDto.Cpf.Length != 11)
                throw new ArgumentException("O CPF é obrigatório e deve conter exatamente 11 dígitos.");

            if (string.IsNullOrWhiteSpace(driverDto.Cnh))
                throw new ArgumentException("A CNH é obrigatória.");

            var driver = new Driver(
                driverDto.Name,
                driverDto.Cpf,
                driverDto.Cnh,
                driverDto.Phone
            );

            await _driverRepository.AddAsync(driver);
        }

        public async Task<DriverDto?> GetByIdAsync(int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver == null) return null;

            return new DriverDto
            {
                Id = driver.Id,
                Name = driver.Name,
                Cpf = driver.Cpf,
                Cnh = driver.Cnh,
                Phone = driver.Phone,
                IsActive = driver.IsActive
            };
        }

        public async Task<IEnumerable<DriverDto>> GetAllAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();

            return drivers.Select(d => new DriverDto
            {
                Id = d.Id,
                Name = d.Name,
                Cpf = d.Cpf,
                Cnh = d.Cnh,
                Phone = d.Phone,
                IsActive = d.IsActive
            });
        }

       
        public Task<IEnumerable<DriverDto>> GetallAsync()
        {
            return GetAllAsync();
        }
    }
}