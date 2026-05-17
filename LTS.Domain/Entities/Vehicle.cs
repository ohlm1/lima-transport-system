using System;

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
            if (string.IsNullOrWhiteSpace(licensePlate) || licensePlate.Length < 7)
                throw new ArgumentException("Invalid license plate.", nameof(licensePlate));

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be empty.", nameof(model));

            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("Brand cannot be empty.", nameof(brand));

            if (year < 1900 || year > DateTime.UtcNow.Year + 1)
                throw new ArgumentException("Invalid vehicle year.", nameof(year));

            if (loadCapacityKg <= 0)
                throw new ArgumentException("Load capacity must be greater than zero.", nameof(loadCapacityKg));

            LicensePlate = licensePlate.ToUpper();
            Model = model;
            Brand = brand;
            Year = year;
            LoadCapacityKg = loadCapacityKg;
            Status = "Available";
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateStatus(string newStatus)
        {
            if (newStatus != "Available" && newStatus != "InTransit" && newStatus != "Maintenance")
                throw new ArgumentException("Invalid vehicle status.");

            Status = newStatus;
        }
    }
}