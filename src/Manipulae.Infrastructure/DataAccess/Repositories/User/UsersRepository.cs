using Manipulae.Domain.Entities;
using Manipulae.Domain.Interface.User;
using Microsoft.EntityFrameworkCore;

namespace Manipulae.Infrastructure.DataAccess.Repositories.User
{
    internal class UsersRepository : 
        IUserReadRepository, 
        IUserWriteRepository, 
        IUserUpdateRepository, 
        IUserDeleteRepository
    {
        private readonly ManipulaeDbContext _dbContext;

        public UsersRepository(ManipulaeDbContext ManipulaeDbContext)
        {
            _dbContext = ManipulaeDbContext;
        }

        public async Task Add(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<bool> ExistUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));    
        }

        public async Task<UserEntity?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<UserEntity> GetByIdAsync(long id)
        {
            return await _dbContext.Users.FirstAsync(user => user.Id == id);
        }

        public void Update(UserEntity req)
        {
            _dbContext.Users.Update(req);
        }

        public async Task DeleteAsync(UserEntity user)
        {
            var userToDelete = await _dbContext.Users.FindAsync(user.Id);

            _dbContext.Users.Remove(userToDelete!);
        }
    }
}
