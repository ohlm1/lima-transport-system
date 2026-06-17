using LTS.Application.DTOs;
using LTS.Application.Interfaces;
using LTS.Domain.Interfaces;
using LTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTS.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

       
        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();

            return vehicles.Select(v => new VehicleDto
            {
                Id = v.Id,
                Model = v.Model,
                Brand = v.Brand,
                Year = v.Year,
                LicensePlate = v.LicensePlate,
                LoadCapacityKg = v.LoadCapacityKg 
            }).ToList();
        }

        public async Task<VehicleDto?> GetByIdAsync(int id)
        {
            var v = await _vehicleRepository.GetByIdAsync(id);

            if (v == null) return null;

            return new VehicleDto
            {
                Id = v.Id,
                Model = v.Model,
                Brand = v.Brand,
                Year = v.Year,
                LicensePlate = v.LicensePlate,
                LoadCapacityKg = v.LoadCapacityKg 
            };
        }

        public async Task AddAsync(VehicleDto vehicleDto)
        {
            var vehicle = new Vehicle(
                vehicleDto.LicensePlate,
                vehicleDto.Model,
                vehicleDto.Brand,
                vehicleDto.Year,
                vehicleDto.LoadCapacityKg 
            );

            await _vehicleRepository.AddAsync(vehicle);
        }
    }
}