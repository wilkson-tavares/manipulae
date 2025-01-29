using Manipulae.Domain.Entities;
using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Security.Cryptography;
using Manipulae.Domain.Interface.Service.LoggedUser;
using Manipulae.Domain.Interface.User;
using Manipulae.Domain.Requests.Users;
using Manipulae.Exception;
using Manipulae.Exception.ExceptionBase;
using FluentValidation.Results;

namespace Manipulae.Application.UseCases.Users.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateRepository _updateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncripter _passwordEncripter;

        public ChangePasswordUseCase(
            ILoggedUser loggedUser,
            IPasswordEncripter passwordEncripter,
            IUserUpdateRepository userUpdateOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _updateRepository = userUpdateOnlyRepository;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
        }

        public async Task Execute(ChangePasswordRequest req)
        {
            var loggedUser = await _loggedUser.GetAsync();

            Validate(req, loggedUser);

            var user = await _updateRepository.GetByIdAsync(loggedUser.Id);
            user.Password = _passwordEncripter.Encrypt(req.NewPassword);

            _updateRepository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(ChangePasswordRequest req, UserEntity loggedUser)
        {
            var validator = new ChangePasswordValidator();

            var result = validator.Validate(req);

            var passwordMatch = _passwordEncripter.Verify(req.Password, loggedUser.Password);

            if (!passwordMatch)
                result.Errors.Add(new ValidationFailure(string.Empty, "Password diferent current password"));

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
