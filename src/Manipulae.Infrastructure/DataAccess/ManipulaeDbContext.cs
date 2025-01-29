using Manipulae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Infrastructure.DataAccess
{
    public class ManipulaeDbContext : DbContext
    {
        public ManipulaeDbContext(DbContextOptions<ManipulaeDbContext> options) : base(options) { }

        public DbSet<VideoEntity> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
