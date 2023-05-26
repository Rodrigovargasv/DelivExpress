using DelivExpress.Shared;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace DelivExpress.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Adciona servi�o dos controladores
            builder.Services.AddControllers().AddJsonOptions(option =>
            option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Adiciona servi�o de inje��o de depend�ncia
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS",builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Delivery.Api", Version = "v1"}));

            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // adiciona o middleware para a defini��o de politicas CORS
            app.UseCors("EnableCORS");

            // configura servi�o dos controladores
            app.MapControllers();
            app.Run();
        }
    }
}