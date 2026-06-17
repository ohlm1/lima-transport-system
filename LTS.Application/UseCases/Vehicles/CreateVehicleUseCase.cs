using System;
using System.Threading.Tasks;
using LTS.Application.Interfaces;
using LTS.Domain.Entities;
using LTS.Domain.Interfaces;

namespace LTS.Application.UseCases.Vehicles
{
    public class CreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> ExecuteAsync(CreateVehicleRequest request)
        {
            var existingVehicle = await _vehicleRepository.GetByLicensePlateAsync(request.LicensePlate);
            if (existingVehicle != null)
            {
                throw new InvalidOperationException("A vehicle with this license plate is already registered.");
            }

            var newVehicle = new Vehicle(
                request.LicensePlate,
                request.Model,
                request.Brand,
                request.Year,
                request.LoadCapacityKg
            );

            await _vehicleRepository.AddAsync(newVehicle);

            return newVehicle;
        }
    }

    public class CreateVehicleRequest
    {
        public string LicensePlate { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public int Year { get; set; }
        public decimal LoadCapacityKg { get; set; }
    }
}