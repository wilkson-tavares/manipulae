using Manipulae.Domain.Requests.Users;
using Manipulae.Exception;
using FluentValidation;

namespace Manipulae.Application.UseCases.Users
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Empty Name");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Empty Email")
                .EmailAddress()
                .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage("Invalid Email");

            RuleFor(user => user.Password)
                .SetValidator(new PasswordValidator<UserRequest>());
        }
    }
}
