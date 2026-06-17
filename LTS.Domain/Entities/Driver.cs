using System;
using System.Linq;
using System.Text.RegularExpressions;

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

           
            if (!ValidateCpf(cpf))
                throw new ArgumentException("CPF inválido. Forneça um CPF real e com 11 dígitos numéricos.", nameof(cpf));

            if (string.IsNullOrWhiteSpace(cnh))
                throw new ArgumentException("A CNH não pode ser vazia.", nameof(cnh));

            Name = name;
            Cpf = CleanCpf(cpf); 
            Cnh = cnh;
            Phone = phone;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

       
        public void UpdateInfo(string name, string phone, string cnh)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome do motorista não pode ser vazio.", nameof(name));

            if (string.IsNullOrWhiteSpace(cnh))
                throw new ArgumentException("A CNH não pode ser vazia.", nameof(cnh));

            Name = name;
            Phone = phone;
            Cnh = cnh;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        #region Validações de Domínio (Business Rules)

        private static string CleanCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return string.Empty;
            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        private static bool ValidateCpf(string cpf)
        {
            var cleanedCpf = CleanCpf(cpf);

            if (cleanedCpf.Length != 11)
                return false;

          
            if (cleanedCpf.Distinct().Count() == 1)
                return false;

          
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cleanedCpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;

            tempCpf += digit1;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;

            return cleanedCpf.EndsWith(digit1.ToString() + digit2.ToString());
        }

        #endregion
    }
}