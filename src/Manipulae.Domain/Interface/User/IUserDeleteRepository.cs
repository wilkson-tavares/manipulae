using Manipulae.Domain.Entities;

namespace Manipulae.Domain.Interface.User
{
    public interface IUserDeleteRepository
    {
        Task DeleteAsync(UserEntity user);
    }
}
