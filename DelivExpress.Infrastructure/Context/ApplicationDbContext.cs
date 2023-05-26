using DelivExpress.Domain.Entites;
using Microsoft.EntityFrameworkCore;


namespace DelivExpress.Infrastructure.Context
{

    // Reliza a configuração com o banco de dados
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // Faz o Mapeamento das tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        // Configura o modelo da fluente api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }
}
