using Manipulae.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new Exception($"Error: ", ex);
            }
        }
    }
}
