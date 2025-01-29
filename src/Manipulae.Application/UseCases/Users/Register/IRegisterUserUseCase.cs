using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Responses.Users;

namespace Manipulae.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        Task<RegisteredUserResponse> Execute(UserRequest req);
    }
}
