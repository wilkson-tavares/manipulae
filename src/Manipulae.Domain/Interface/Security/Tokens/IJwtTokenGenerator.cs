using Manipulae.Domain.Entities;

namespace Manipulae.Domain.Interface.Security.Tokens
{
    public interface IJwtTokenGenerator
    {
        string Generate(UserEntity userEntity);
    }
}
