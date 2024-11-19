using Microsoft.Extensions.DependencyInjection;
using OrderFlowManager.Business.Interfaces;
using OrderFlowManager.Business.Servicios;

namespace OrderFlowManager.Business.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStateServices, OrderStateServices>();

            return services;
        }
    }
}
