using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruitment.Infrastructure.Models;

namespace Sat.Recruitment.Infrastructure.Services.Abstract
{
    /// <summary>   
    /// User Infrastructure Services Interface
    /// </summary>
    public interface IUserInfrastructureService
    {
        /// <summary>
        /// Get a list of users
        /// </summary>
        /// <returns>List of users</returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// create user
        /// </summary>
        /// <returns>boolean</returns>
        Task<bool> CreateUser(User newUser);

    }
}
