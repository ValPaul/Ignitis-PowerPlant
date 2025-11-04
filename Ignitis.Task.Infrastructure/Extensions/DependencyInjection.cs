using Ignitis.Application.Abstractions;
using Ignitis.Infrastructure.Repositories;
using Ignitis.Infrastructure.SqlStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("PowerPlant")
                ?? throw new InvalidOperationException("ConnectionStrings:PowerPlant is missing in appsettings.json");

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connString));

            services.AddDbContext<ReadOnlyAppDbContext>(o =>
                o.UseNpgsql(connString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IPowerPlantRepository, PowerPlantRepository>();

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
