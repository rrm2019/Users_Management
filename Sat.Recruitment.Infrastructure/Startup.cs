using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Infrastructure.Services.Abstract;
using Sat.Recruitment.Infrastructure.Services.Implementation;
using AutoMapper;

namespace Sat.Recruitment.Infrastructure
{
    /// <summary>
    /// Infraestructure layer inizialization class
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Infraestructure layer dependncy registration
        /// </summary>
        /// <param name="services">Current services collection</param>
        /// <returns>Services collection modified with services infrastructure layer</returns>
        public static IServiceCollection InitInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserInfrastructureService, UserInfrastructureService>();
            services.AddTransient(provider =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                const string categoryName = "Logger";
                return loggerFactory.CreateLogger(categoryName);
            });
            return services;

        }
    }
}
