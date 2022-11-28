using Sat.Recruitment.Application.Services.Abstract;
using Sat.Recruitment.Application.DTO;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;
using System;
using Sat.Recruitment.Infrastructure.Services.Abstract;
using System.Collections.Generic;
using Sat.Recruitment.Infrastructure.Models;
using Sat.Recruitment.Application.Constants;
using AutoMapper;
using Sat.Recruitment.Application.Helpers;
using Microsoft.Extensions.Logging;

namespace Sat.Recruitment.Application.Services.Implementation
{
    /// <summary>
    /// User Application Services
    /// </summary>
    /// <seealso cref="IUserService" />
    public class UserService : IUserService
    {
        private readonly IValidator<UserDto> _requestUserValidator;
        private readonly IUserInfrastructureService _userInfrastructureService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor: Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="requestUserValidator">Object Validator</param>
        /// <param name="userInfrastructureService">Logger</param>
        /// <param name="mapper">Logger</param>
        /// <param name="logger">Logger</param>
        public UserService(IValidator<UserDto> requestUserValidator, IUserInfrastructureService userInfrastructureService, IMapper mapper, ILogger logger)
        {
            _requestUserValidator = requestUserValidator;
            _userInfrastructureService = userInfrastructureService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<Result> CreateUser(UserDto newUser)
        {
            ValidateUser(newUser, _requestUserValidator);
            try
            {
                var users = await _userInfrastructureService.GetUsers();
                IsUserDuplicated(users, newUser);

                var user = _mapper.Map<User>(newUser);
     
                GetUserType(user, newUser);

                var result = await _userInfrastructureService.CreateUser(user);

                if (result)
                {
                    return new Result()
                    {
                        IsSuccess = true,
                        Errors = Success.USER_CREATED
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(Errors.ERROR_USER_CREATED, e.ToString());
                throw new AppException(Errors.ERROR_USER_CREATED, e.ToString());
            }

            return new Result()
            {
                IsSuccess = false,
                Errors = Errors.ERROR_USER_CREATED
            };
        }

        private void GetUserType(User user, UserDto newUser)
        {
            var percentage = Convert.ToDecimal(0);
            switch (newUser.UserType.ToLower())
            {
                case UserType.USER_TYPE_NORMAL:
                    if (newUser.Money > 100)
                    {
                        percentage = Convert.ToDecimal(0.12);
                    }
                    if (newUser.Money < 100)
                    {
                        if (newUser.Money > 10)
                        {
                            percentage = Convert.ToDecimal(0.8);
                        }
                    }
                    break;
                case UserType.USER_TYPE_SUPER_USER:
                    if (newUser.Money > 100)
                    {
                        percentage = Convert.ToDecimal(0.20);
                    }
                    break;
                case UserType.USER_TYPE_PREMIUM:
                    if (newUser.Money > 100)
                    {
                        percentage = 2;
                    }
                    break;
                default:
                    break;
            }

            var gif = newUser.Money * percentage;
            user.Money = newUser.Money + gif;
        }

        private void ValidateUser(UserDto user, IValidator<UserDto> requestScheduleDtoValidator)
        {
            var resultsValidations = requestScheduleDtoValidator.Validate(user);
            if (resultsValidations != null && !resultsValidations.IsValid)
            {
                _logger.LogError(string.Join("; ", resultsValidations.Errors.Select(c => c.ErrorMessage)));
                throw new AppException(string.Join("; ", resultsValidations.Errors.Select(c => c.ErrorMessage)));
            }
        }

        private void IsUserDuplicated(IEnumerable<User> users, UserDto newUser)
        {
            var hasDuplicates = false;
            foreach (var user in users)
            {
                hasDuplicates =
                    user.Email.Equals(newUser.Email) || user.Phone.Equals(newUser.Phone) ||
                    (user.Name.ToLower().Equals(newUser.Name.ToLower()) && user.Address.ToLower().Equals(newUser.Address.ToLower())) ? true : false;

                if (hasDuplicates)
                {
                    _logger.LogError(Errors.ERROR_USER_DUPLICATED);
                    throw new AppException(Errors.ERROR_USER_DUPLICATED);
                }
            }
        }
    }
}
