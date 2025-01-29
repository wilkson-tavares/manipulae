using Manipulae.Domain.Entities;
using Manipulae.Domain.Interface.Security.Tokens;
using Manipulae.Domain.Interface.Service.LoggedUser;
using Manipulae.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Manipulae.Infrastructure.Service.LoggedUser
{
    internal class LoggedUser : ILoggedUser
    {
        private readonly ManipulaeDbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(ManipulaeDbContext ManipulaeDbContext, ITokenProvider tokenProvider)
        {
            _dbContext = ManipulaeDbContext;
            _tokenProvider = tokenProvider;
        }

        public async Task<UserEntity> GetAsync()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _dbContext
                .Users
                .AsNoTracking()
                .FirstAsync(user => user.UserId == Guid.Parse(identifier));
        }
    }
}
