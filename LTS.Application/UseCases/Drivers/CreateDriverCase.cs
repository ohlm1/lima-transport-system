using System;
using System.Threading.Tasks;
using LTS.Application.Interfaces;
using LTS.Domain.Entities;
using LTS.Domain.Interfaces;

namespace LTS.Application.UseCases.Drivers
{
    public class CreateDriverUseCase
    {
        private readonly IDriverRepository _driverRepository;

        public CreateDriverUseCase(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Driver> ExecuteAsync(CreateDriverRequest request)
        {
            var existingDriver = await _driverRepository.GetByCpfAsync(request.Cpf);
            if (existingDriver != null)
            {
                throw new InvalidOperationException("A driver with this CPF is already registered.");
            }

            var newDriver = new Driver(request.Name, request.Cpf, request.Cnh, request.Phone);

            await _driverRepository.AddAsync(newDriver);

            return newDriver;
        }
    }

    public class CreateDriverRequest
    {
        public string Name { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Cnh { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}