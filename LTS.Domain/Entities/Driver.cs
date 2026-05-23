using System;
using System.Runtime.ConstrainedExecution;

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
                throw new ArgumentException("O nome do motorista não pode ser vazio.", nameof(name));

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                throw new ArgumentException("CPF inválido. O campo deve conter exatamente 11 caracteres.", nameof(cpf));

            if (string.IsNullOrWhiteSpace(cnh))
                throw new ArgumentException("A CNH não pode ser vazia.", nameof(cnh));

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