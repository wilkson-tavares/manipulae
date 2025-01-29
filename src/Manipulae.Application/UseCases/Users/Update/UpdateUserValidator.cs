using Manipulae.Domain.Requests.Users;
using Manipulae.Exception;
using FluentValidation;

namespace Manipulae.Application.UseCases.Users.Update
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Empty Name");
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Empty Email")
                .EmailAddress()
                .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage("Invalid Email");
        }
    }
}
