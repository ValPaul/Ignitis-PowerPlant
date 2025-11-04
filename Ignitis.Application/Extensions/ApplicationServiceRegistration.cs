using FluentValidation;
using Ignitis.Application.Interfaces;
using Ignitis.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ignitis.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPowerPlantService, PowerPlantService>();

            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

            return services;
        }
    }
}
