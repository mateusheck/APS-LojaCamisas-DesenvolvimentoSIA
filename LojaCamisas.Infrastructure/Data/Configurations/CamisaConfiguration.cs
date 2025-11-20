using LojaCamisas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaCamisas.Infrastructure.Data.Configurations
{
    public class CamisaConfiguration : IEntityTypeConfiguration<Camisa>
    {
        public void Configure(EntityTypeBuilder<Camisa> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Preco).HasPrecision(10, 2).IsRequired();

            builder.HasOne(c => c.Marca)
                 .WithMany(m => m.Camisas!)
                 .HasForeignKey(c => c.MarcaId)
                 .IsRequired();
        }
    }
}