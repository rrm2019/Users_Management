using AutoFixture;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Validators;
using Xunit;
using FluentAssertions;
using Sat.Recruitment.Application.Constants;

namespace Sat.Recruitment.Test.Application.Validators
{
    public class UserValidatorTest
    {
        private static readonly Fixture _fixture = new Fixture();
        private static readonly UserValidator _sut = new UserValidator();

        [Fact]
        public void WhenValidating_User_Data_ReturnsIsValid()
        {
            var dto = _fixture.Create<UserDto>();
            dto.Email = "example@example.com";

            var validationResult = _sut.Validate(dto);

            validationResult.Should().NotBeNull();
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public void WhenValidating_User_Data_ReturnsValidationError()
        {
            var dto = _fixture.Create<UserDto>();
            dto.Email = "example@example";

            var validationResult = _sut.Validate(dto);

            validationResult.Should().NotBeNull();
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().ContainSingle(x => x.ErrorMessage == ValidationError.ERROR_VALIDATION_EMAIL_NOT_VALID);
        }

    }
}
