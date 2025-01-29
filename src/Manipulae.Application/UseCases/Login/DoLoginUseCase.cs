using Manipulae.Domain.Interface.Security.Cryptography;
using Manipulae.Domain.Interface.Security.Tokens;
using Manipulae.Domain.Interface.User;
using Manipulae.Domain.Requests.Login;
using Manipulae.Domain.Responses.Users;
using Manipulae.Exception.ExceptionBase;

namespace Manipulae.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public DoLoginUseCase(
            IUserReadRepository userReadRepository,
            IPasswordEncripter passwordEncripter,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userReadRepository = userReadRepository;
            _passwordEncripter = passwordEncripter;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RegisteredUserResponse> Execute(LoginRequest req)
        {
            var user = await _userReadRepository.GetUserByEmail(req.Email) 
                ?? throw new InvalidLoginException();

            var passwordMatch = _passwordEncripter.Verify(req.Password, user.Password);

            if (passwordMatch is false)
                throw new InvalidLoginException();

            return new RegisteredUserResponse
            {
                Name = user.Name,
                Token = _jwtTokenGenerator.Generate(user)
            };
        }
    }
}
