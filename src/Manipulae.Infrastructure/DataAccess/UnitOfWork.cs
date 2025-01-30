using Manipulae.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Manipulae.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManipulaeDbContext _dbContext;

        public UnitOfWork(ManipulaeDbContext manipulaeDbContext)
        {
            _dbContext = manipulaeDbContext;
        }
        public async Task Commit()
        {
            try
            {
                if (_dbContext.ChangeTracker.HasChanges())
                    await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new System.Exception($"Error: ", ex); // Fully qualify the Exception type
            }
        }
    }
}
