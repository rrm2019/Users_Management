using System.Threading.Tasks;
using Sat.Recruitment.Application.DTO;

namespace Sat.Recruitment.Application.Services.Abstract
{
    /// <summary>   
    /// User Application Services Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">user data to create</param>
        /// <returns>Result DTO</returns>
        Task<Result> CreateUser(UserDto user);

    }
}
