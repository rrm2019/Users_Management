using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Services.Abstract;
using Xunit;

namespace Sat.Recruitment.Test.Api
{
    public class UserControllerTest
    {
        [Fact]
        public async Task CreateUser_is_OK()
        {
            Mock<IUserService> serviceMock = new Mock<IUserService>();
            var loggerMock = new Mock<ILogger>();
            var user = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var userController = new UsersController(serviceMock.Object, loggerMock.Object);

            var result = await userController.CreateUser(user);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
