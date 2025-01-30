using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Service.LoggedUser;
using Manipulae.Domain.Interface.User;
using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Responses.Users;
using Manipulae.Exception;
using Manipulae.Exception.ExceptionBase;

namespace Manipulae.Application.UseCases.Users.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateRepository _repository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserUseCase(
            ILoggedUser loggedUser,
            IUserUpdateRepository userUpdateRepository,
            IUserReadRepository userReadRepository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _userReadRepository = userReadRepository;
            _repository = userUpdateRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserProfileResponse> Execute(UpdateUserRequest req)
        {
            var loggedUser = await _loggedUser.GetAsync(); ///fazer o mesmo para o service do youtube

            await Validate(req, loggedUser.Email);

            var user = await _repository.GetByIdAsync(loggedUser.Id);

            user.Name = req.Name;
            user.Email = req.Email;

            _repository.Update(user);

            await _unitOfWork.Commit();

            return new UserProfileResponse
            {
                Name = user.Name,
                Email = user.Email
            };
        }

        private async Task Validate(UpdateUserRequest req, string currentEmail)
        {
            var validator = new UpdateUserValidator();

            var result = validator.Validate(req);

            if (!currentEmail.Equals(req.Email))
            {
                var userExist = await _userReadRepository.ExistUserWithEmail(req.Email);
                if (userExist)
                    result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, "Email already registered"));
            }

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(err => err.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
