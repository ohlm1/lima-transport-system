using System;

namespace LTS.Application.DTOs
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal LoadCapacityKg { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}