using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Services.Abstract;
using Sat.Recruitment.Infrastructure.Services.Abstract;
using Sat.Recruitment.Infrastructure.Services.Implementation;

namespace Sat.Recruitment.Test
{
    public class Startup
    {
        public static Startup Instance
        {
            get
            {
                return Create();
            }
        }

        public IServiceCollection ServiceCollection { get; private set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        public static Startup Create()
        {
            Startup startup = new Startup();

            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false)
               .AddEnvironmentVariables()
               .Build();
            services.AddSingleton(configuration);

            //Agregar Logger Mock
            Mock<ILogger> loggerStub = new Mock<ILogger>();
            services.AddScoped(typeof(ILogger), (mock) => loggerStub.Object);

            Mock<ValidationResult> validationResult = new Mock<ValidationResult>();
            services.AddScoped(typeof(ValidationResult), (mock) => validationResult.Object);

            var userValidation = new Mock<IValidator<UserDto>>();
            services.AddScoped(typeof(IValidator<UserDto>), (mock) => userValidation.Object);

            services.AddAutoMapper(typeof(IUserService).Assembly);
            startup.ServiceCollection = services;


            services.AddScoped<IUserInfrastructureService, UserInfrastructureService>();

            return startup;
        }
    }
}
