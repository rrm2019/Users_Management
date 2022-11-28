using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Infrastructure.Constans;
using Sat.Recruitment.Infrastructure.Models;
using Sat.Recruitment.Infrastructure.Services.Abstract;

namespace Sat.Recruitment.Infrastructure.Services.Implementation
{
    public class UserInfrastructureService : IUserInfrastructureService
    {
        private const string PATH_FILE = "/Files/Users.txt";

        private readonly ILogger _logger;

        /// <summary>
        /// Constructor: Initializes a new instance of the <see cref="UserInfrastructureService"/> class.
        /// </summary>
        /// <param name="logger">Logger</param>
        public UserInfrastructureService(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<User>> GetUsers()
        {
            _logger.LogInformation("Call to GetUsers Infrastructure");

            List<User> users = new List<User>();
            var path = Directory.GetCurrentDirectory() + PATH_FILE;
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fileStream);

                while (sr.Peek() >= 0)
                {
                    var line = await sr.ReadLineAsync();
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    users.Add(user);
                }

                sr.Dispose();
            }
            catch (Exception e)
            {
                _logger.LogError(Errors.ERROR_EXCEPTION, e.ToString());
                throw new ArgumentException(Errors.ERROR_EXCEPTION, e.ToString());
            }
            return users;
        }

        /// <inheritdoc />
        public async Task<bool> CreateUser(User newUser)
        {
            _logger.LogInformation("Call to CreateUser Infrastructure");

            var path = Directory.GetCurrentDirectory() + PATH_FILE;
            try
            {
                StreamWriter sw = File.AppendText(path);

                var line = string.Join(",", newUser.Name, newUser.Email, newUser.Phone, 
                    newUser.Address, newUser.UserType, newUser.Money);
                await sw.WriteLineAsync(line);

                sw.Dispose();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(Errors.ERROR_EXCEPTION, e.ToString());
                throw new ArgumentException(Errors.ERROR_EXCEPTION, e.ToString()); 
            }
        }
    }
}
