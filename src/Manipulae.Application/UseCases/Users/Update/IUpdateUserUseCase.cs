using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Responses.Users;

namespace Manipulae.Application.UseCases.Users.Update
{
    public interface IUpdateUserUseCase
    {
        Task<UserProfileResponse> Execute(UpdateUserRequest req);
    }
}
