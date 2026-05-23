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
                throw new ArgumentException("A placa do veículo é inválida ou incompleta.", nameof(licensePlate));

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("O modelo não pode ser vazio.", nameof(model));

            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("A marca não pode ser vazia.", nameof(brand));

            if (year < 1900 || year > DateTime.UtcNow.Year + 1)
                throw new ArgumentException("O ano do veículo informado é inválido.", nameof(year));

            if (loadCapacityKg <= 0)
                throw new ArgumentException("A capacidade de carga deve ser maior que zero.", nameof(loadCapacityKg));


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
                throw new ArgumentException("Status de veículo inválido.");

            Status = newStatus;
        }
    }
}