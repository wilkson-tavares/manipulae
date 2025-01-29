using Manipulae.Domain.Requests.Users;

namespace Manipulae.Application.UseCases.Users.ChangePassword
{
    public interface IChangePasswordUseCase
    {
        Task Execute(ChangePasswordRequest req);
    }
}
