using Manipulae.Domain.Entities;

namespace Manipulae.Domain.Interface.User
{
    public interface IUserUpdateRepository
    {
        Task<UserEntity> GetByIdAsync(long id);
        void Update(UserEntity req);
    }
}
