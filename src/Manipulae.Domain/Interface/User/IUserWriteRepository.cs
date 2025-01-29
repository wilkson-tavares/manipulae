using Manipulae.Domain.Entities;

namespace Manipulae.Domain.Interface.User
{
    public interface IUserWriteRepository
    {
        Task Add(UserEntity user);
    }
}
