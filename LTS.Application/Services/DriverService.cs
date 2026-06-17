using LTS.Application.DTOs;
using LTS.Infrastructure.Data.Repositories;
using LTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTS.Application.Interfaces;

namespace LTS.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly DriverRepository _driverRepository;

        public DriverService(DriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        // 1. Mudamos de RegisterAsync para CreateAsync para bater com a Interface
        public async Task<DriverDto> CreateAsync(DriverDto driverDto)
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

            // Atualiza o ID no DTO que vamos retornar para a API
            driverDto.Id = driver.Id;
            driverDto.IsActive = driver.IsActive;

            return driverDto;
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

        // 2. Adicionado o UpdateAsync que o contrato pedia
        public async Task<bool> UpdateAsync(int id, DriverDto driverDto)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver == null) return false;

            // Aqui você atualizará as propriedades da sua entidade baseada no DTO
            // Exemplo: driver.UpdateInfo(driverDto.Name, driverDto.Phone...);

            await _driverRepository.UpdateAsync(driver);
            return true;
        }

        // 3. Adicionado o DeleteAsync (Inativação) que o contrato pedia
        public async Task<bool> DeleteAsync(int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver == null) return false;

            // Num sistema real, a gente desativa em vez de excluir
            driver.Deactivate(); // Ou a lógica correspondente que você tiver na Entity

            await _driverRepository.UpdateAsync(driver);
            return true;
        }
    }
}