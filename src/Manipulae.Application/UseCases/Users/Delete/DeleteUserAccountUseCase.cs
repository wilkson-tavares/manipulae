using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Service.LoggedUser;
using Manipulae.Domain.Interface.User;

namespace Manipulae.Application.UseCases.Users.Delete
{
    public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;
        private readonly IUserDeleteRepository _userDeleteRepository;

        public DeleteUserAccountUseCase(
            IUnitOfWork unitOfWork,
            ILoggedUser loggedUser,
            IUserDeleteRepository userDeleteRepository)
        {
            _unitOfWork = unitOfWork;
            _loggedUser = loggedUser;
            _userDeleteRepository = userDeleteRepository;
        }

        public async Task Execute()
        {
            var user = await _loggedUser.GetAsync();
            await _userDeleteRepository.DeleteAsync(user);

            await _unitOfWork.Commit();
        }
    }
}
