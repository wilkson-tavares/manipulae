using Manipulae.Domain.Entities;
using Manipulae.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoEntity>()
           .Property(v => v.Duracao)
           .HasConversion(
               v => v.ToString(),
               v => (VideoDurationEnum)Enum.Parse(typeof(VideoDurationEnum), v));
        }
    }
}
