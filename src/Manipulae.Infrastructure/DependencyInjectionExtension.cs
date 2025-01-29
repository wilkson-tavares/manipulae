using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Video;
using Manipulae.Infrastructure.DataAccess;
using Manipulae.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ManipulaeDbContext>(options =>
                options.UseSqlite(connectionString));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVideoDeleteRepository, VideoRepository>();
            services.AddScoped<IVideoReadRepository, VideoRepository>();
            services.AddScoped<IVideoUpdateRepository, VideoRepository>();
            services.AddScoped<IVideoWriteRepository, VideoRepository>();
        }
    }
}
