using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderFlowManager.Domain.Interfaces;
using OrderFlowManager.Persistencia.Data;
using OrderFlowManager.Persistencia.Repositories;

namespace OrderFlowManager.Persistencia.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registrar repositorios
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStateRepository, OrderStateRepository>();

            return services;
        }
    }
}
