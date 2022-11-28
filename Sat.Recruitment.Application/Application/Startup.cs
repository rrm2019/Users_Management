using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Services.Abstract;
using Sat.Recruitment.Application.Services.Implementation;
using Sat.Recruitment.Infrastructure;

namespace Sat.Recruitment.Application
{
    /// <summary>
    /// Application layer initialization class
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Application layer dependency registration
        /// </summary>
        /// <param name="services">Services collection</param>
        /// <returns>Services collection modified with services layer</returns>
        public static IServiceCollection InitApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.InitInfrastructureLayer(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserService, UserService>();
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
