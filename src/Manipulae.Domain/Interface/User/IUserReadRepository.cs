using Manipulae.Domain.Entities;

namespace Manipulae.Domain.Interface.User
{
    public interface IUserReadRepository
    {
        Task<bool> ExistUserWithEmail(string email);
        Task<UserEntity?> GetUserByEmail(string email);
    }
}
