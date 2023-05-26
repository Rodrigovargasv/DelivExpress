
using DelivExpress.Application.Interfaces;
using DelivExpress.Application.Mappings;
using DelivExpress.Application.Service;
using DelivExpress.Domain.Interfaces;
using DelivExpress.Infrastructure.Context;
using DelivExpress.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace DelivExpress.Shared
{
    // Define o serviço de injeção de dependência para comunicação correta como todo o projeto e banco de dados.
    // Realizando a inversão de controle.
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)

        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddAutoMapper(typeof(ApplicationDbContext));
            
            
            return services;
        }
    }
}
