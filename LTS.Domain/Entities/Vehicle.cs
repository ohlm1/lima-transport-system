using System;
using System.Text.RegularExpressions;

namespace LTS.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; private set; }
        public string LicensePlate { get; private set; }
        public string Model { get; private set; }
        public string Brand { get; private set; }
        public int Year { get; private set; }
        public decimal LoadCapacityKg { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected Vehicle()
        {
            LicensePlate = null!;
            Model = null!;
            Brand = null!;
            Status = null!;
        }

        public Vehicle(string licensePlate, string model, string brand, int year, decimal loadCapacityKg)
        {
          
            if (!ValidatePlate(licensePlate))
                throw new ArgumentException("A placa do veículo é inválida. Use o formato tradicional (ABC-1234) ou Mercosul (ABC1D23).", nameof(licensePlate));

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("O modelo não pode ser vazio.", nameof(model));

            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("A marca não pode ser vazia.", nameof(brand));

            if (year < 1900 || year > DateTime.UtcNow.Year + 1)
                throw new ArgumentException("O ano do veículo informado é inválido.", nameof(year));

            if (loadCapacityKg <= 0)
                throw new ArgumentException("A capacidade de carga deve ser maior que zero.", nameof(loadCapacityKg));

           
            LicensePlate = CleanPlate(licensePlate);
            Model = model;
            Brand = brand;
            Year = year;
            LoadCapacityKg = loadCapacityKg;
            Status = "Available";
            CreatedAt = DateTime.UtcNow;
        }

        
        public void UpdateInfo(string model, string brand, int year, decimal loadCapacityKg)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("O modelo não pode ser vazio.", nameof(model));

            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("A marca não pode ser vazia.", nameof(brand));

            if (year < 1900 || year > DateTime.UtcNow.Year + 1)
                throw new ArgumentException("O ano do veículo informado é inválido.", nameof(year));

            if (loadCapacityKg <= 0)
                throw new ArgumentException("A capacidade de carga deve ser maior que zero.", nameof(loadCapacityKg));

            Model = model;
            Brand = brand;
            Year = year;
            LoadCapacityKg = loadCapacityKg;
        }

        public void UpdateStatus(string newStatus)
        {
            if (newStatus != "Available" && newStatus != "InTransit" && newStatus != "Maintenance")
                throw new ArgumentException("Status de veículo inválido.");

            Status = newStatus;
        }

        #region Validações de Domínio (Business Rules)

        private static string CleanPlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) return string.Empty;
            return plate.Replace("-", "").Replace(" ", "").ToUpper();
        }

        private static bool ValidatePlate(string plate)
        {
            var cleanedPlate = CleanPlate(plate);

           
            var pattern = @"^[A-Z]{3}[0-9]{1}[A-Z0-9]{1}[0-9]{2}$";

            return Regex.IsMatch(cleanedPlate, pattern);
        }

        #endregion
    }
}