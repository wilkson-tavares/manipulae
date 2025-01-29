using Manipulae.Domain.Responses.Users;

namespace Manipulae.Application.UseCases.Users.Profile
{
    public interface IGetUserProfileUseCase
    {
        Task<UserProfileResponse> Execute();
    }
}
