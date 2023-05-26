using DelivExpress.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DelivExpress.Infrastructure.EntitiesConfiguration
{
    // Define as regras da fluent api, para criação da tabela Categorias no banco de dados.
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(100).IsRequired();
            
            
        }
    }
}
