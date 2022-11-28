
using System;
using AutoMapper;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Infrastructure.Models;

namespace Sat.Recruitment.Application.Mappers
{
    /// <summary>
    /// User Profile Dto Mapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    internal class UserProfile : Profile
    {
        /// <summary>
        /// Default Constructor: Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
