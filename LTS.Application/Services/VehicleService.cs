using LTS.Application.DTOs; 
using LTS.Infrastructure.Data.Repositories;
using LTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTS.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task RegisterAsync(VehicleDto vehicleDto)
        {
            if (string.IsNullOrWhiteSpace(vehicleDto.LicensePlate))
                throw new ArgumentException("A placa do veículo é obrigatória.");

            if (vehicleDto.Year < 1900 || vehicleDto.Year > DateTime.Now.Year + 1)
                throw new ArgumentException("O ano do veículo informado é inválido.");

            var vehicle = new Vehicle(
                vehicleDto.LicensePlate,
                vehicleDto.Model,
                vehicleDto.Brand,
                vehicleDto.Year,
                vehicleDto.LoadCapacityKg
            );

            await _vehicleRepository.AddAsync(vehicle);
        }

        public async Task<VehicleDto?> GetByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null) return null;

            return new VehicleDto
            {
                Id = vehicle.Id,
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                LoadCapacityKg = vehicle.LoadCapacityKg,
                Status = vehicle.Status
            };
        }

        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return vehicles.Select(v => new VehicleDto
            {
                Id = v.Id,
                LicensePlate = v.LicensePlate,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                LoadCapacityKg = v.LoadCapacityKg,
                Status = v.Status
            });
        }
    }
}