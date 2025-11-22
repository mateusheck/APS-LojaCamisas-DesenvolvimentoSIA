using LojaCamisas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaCamisas.Infrastructure.Data.Configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome).HasMaxLength(150).IsRequired();

            builder.HasMany(m => m.Camisas!) 
                   .WithOne(c => c.Marca!)   
                   .HasForeignKey(c => c.MarcaId) 
                   .IsRequired();
        }
    }
}