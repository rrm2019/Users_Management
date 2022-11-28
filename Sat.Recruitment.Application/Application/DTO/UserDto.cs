
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Application.DTO
{
    /// <summary>
    /// Class indicating user information
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Property indicating the name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property indicating the email of the user
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Property indicating the address of the user
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Property indicating the phone of the user
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Property indicating the type of the user
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// Property indicating the money of the user
        /// </summary>
        public decimal Money { get; set; }
    }
}
