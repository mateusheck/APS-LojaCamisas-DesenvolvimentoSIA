using LojaCamisas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaCamisas.Infrastructure.Data.Configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            // Define a chave primária
            builder.HasKey(m => m.Id);

            // Mapeia a propriedade Nome
            builder.Property(m => m.Nome).HasMaxLength(150).IsRequired();

            // Configura o relacionamento One-to-Many
            // Uma Marca tem muitas Camisas, e Camisa tem uma Marca.
            builder.HasMany(m => m.Camisas!) // A coleção Camisas
                   .WithOne(c => c.Marca!)   // Mapeada para a propriedade Marca na Camisa
                   .HasForeignKey(c => c.MarcaId) // Usando a chave estrangeira MarcaId
                   .IsRequired();
        }
    }
}