
using Auth.Infrastructure.Module;
using Ecommerce.Abstractions.Hosting;
using Ecommerce.Infrastructure.Module;
using Ecommerce.WebApi.Extensions;

namespace Ecommerce.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //registrar módulos
            var modules = new List<IModule>
            {
                new InfrastructureModule(),
                new AuthModule(),
                // futuros módulos como ComprasModule, InventarioModule...
            };

            foreach (var module in modules)
            {
                module.RegisterServices(builder.Services, builder.Configuration);
            }


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           

            app.UseCustomAuth();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
