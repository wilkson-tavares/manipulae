using Manipulae.Domain.Requests.Login;
using Manipulae.Domain.Responses.Users;

namespace Manipulae.Application.UseCases.Login
{
    public interface IDoLoginUseCase
    {
        Task<RegisteredUserResponse> Execute(LoginRequest req);
    }
}
