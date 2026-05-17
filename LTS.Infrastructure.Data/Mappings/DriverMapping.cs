using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LTS.Domain.Entities;

namespace LTS.Infrastructure.Data.Mappings
{
    public class DriverMapping : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(d => d.Cpf)
                .IsRequired()
                .HasMaxLength(11);

        
            builder.HasIndex(d => d.Cpf)
                .IsUnique();

            builder.Property(d => d.Cnh)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Phone)
                .HasMaxLength(20); 

            builder.Property(d => d.IsActive)
                .IsRequired();

            builder.Property(d => d.CreatedAt)
                .IsRequired();
        }
    }
}