using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Services.Abstract;
using FluentValidation.Results;
using FluentValidation;
using Moq;
using Sat.Recruitment.Application.Helpers;
using Task = System.Threading.Tasks.Task;
using Sat.Recruitment.Application.Services.Implementation;
using Sat.Recruitment.Infrastructure.Services.Abstract;
using Sat.Recruitment.Infrastructure.Services.Implementation;

namespace Sat.Recruitment.Test.Application.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private static readonly IServiceCollection _serviceCollection = Startup.Instance.ServiceCollection;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _serviceCollection.AddTransient<IUserService, UserService>();
            _serviceCollection.AddTransient(typeof(IUserInfrastructureService), typeof(UserInfrastructureService));
            _fixture = new Fixture();
        }

        [TestMethod]
        public async Task Create_User_Returns_Exception()
        {
            var userDto = _fixture.Create<UserDto>();
            userDto.Email = "example@example";

            var validationResultStub = new Mock<ValidationResult>();
            validationResultStub
                .Setup(v => v.IsValid)
                .Returns(false);

            var validatorStub = new Mock<IValidator<UserDto>>();
            validatorStub
                .Setup(c => c.Validate(It.IsAny<UserDto>()))
                .Returns(validationResultStub.Object);

            var serviceScope = _serviceCollection.BuildServiceProvider().CreateScope();
            var sut = serviceScope.ServiceProvider.GetService<IUserService>();

            Task result() => sut.CreateUser(userDto);
            await Assert.ThrowsExceptionAsync<AppException>(result);
        }
    }
}
