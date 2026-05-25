using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LTS.Infrastructure.Data.Context;

namespace LTS.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Lembre-se de colocar a sua senha do PostgreSQL aqui
            var connectionString = "Server=localhost;Port=5432;Database=LimaTransportSystemDb;User Id=postgres;Password=123;";

            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}