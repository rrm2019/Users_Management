using System.Text.RegularExpressions;
using FluentValidation;
using Sat.Recruitment.Application.Constants;
using Sat.Recruitment.Application.DTO;

namespace Sat.Recruitment.Application.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            var regexEmail = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            RuleFor(dto => dto.Name).NotNull().WithMessage(ValidationError.ERROR_VALIDATION_NAME_EMPTY_OR_NULL);
            RuleFor(dto => dto.Email).NotNull().WithMessage(ValidationError.ERROR_VALIDATION_EMAIL_EMPTY_OR_NULL)
                .EmailAddress().Matches(regexEmail).WithMessage(ValidationError.ERROR_VALIDATION_EMAIL_NOT_VALID);
            RuleFor(dto => dto.Address).NotNull().WithMessage(ValidationError.ERROR_VALIDATION_ADDRESS_EMPTY_OR_NULL);
            RuleFor(dto => dto.Phone).NotNull().WithMessage(ValidationError.ERROR_VALIDATION_PHONE_EMPTY_OR_NULL);
           
        }
    }
}
