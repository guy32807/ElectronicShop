using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure.Extensions
{
    public static class InfraServices
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add infrastructure services here in the future
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("OrderConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddLogging();
            return services;
        }
    }
}
