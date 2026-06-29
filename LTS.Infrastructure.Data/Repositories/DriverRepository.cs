using Microsoft.EntityFrameworkCore;
using LTS.Domain.Entities;
using LTS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LTS.Infrastructure.Data.Context;

namespace LTS.Infrastructure.Data.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _context;

        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task<Driver?> GetByIdAsync(int id)
        {
            return await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Driver?> GetByCpfAsync(string cpf)
        {
            return await _context.Drivers.FirstOrDefaultAsync(d => d.Cpf == cpf);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task UpdateAsync(Driver driver)
        {
            _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();
        }
    }
}