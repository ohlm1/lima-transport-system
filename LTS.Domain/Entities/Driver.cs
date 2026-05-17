using System;

namespace LTS.Domain.Entities
{
    public class Driver
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Cnh { get; private set; }
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

       
        protected Driver()
        {
            Name = null!;
            Cpf = null!;
            Cnh = null!;
            Phone = null!;
        }

      
        public Driver(string name, string cpf, string cnh, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                throw new ArgumentException("Invalid CPF. It must have exactly 11 characters.", nameof(cpf));

            if (string.IsNullOrWhiteSpace(cnh))
                throw new ArgumentException("CNH cannot be empty.", nameof(cnh));

            Name = name;
            Cpf = cpf;
            Cnh = cnh;
            Phone = phone;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}