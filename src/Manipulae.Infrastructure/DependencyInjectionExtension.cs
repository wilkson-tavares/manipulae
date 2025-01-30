using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Security.Cryptography;
using Manipulae.Domain.Interface.Security.Tokens;
using Manipulae.Domain.Interface.Service.LoggedUser;
using Manipulae.Domain.Interface.Service.YoutubeApi;
using Manipulae.Domain.Interface.User;
using Manipulae.Domain.Interface.Video;
using Manipulae.Infrastructure.DataAccess;
using Manipulae.Infrastructure.DataAccess.Repositories.User;
using Manipulae.Infrastructure.DataAccess.Repositories.Video;
using Manipulae.Infrastructure.Security.Cryptography;
using Manipulae.Infrastructure.Security.Tokens;
using Manipulae.Infrastructure.Service.LoggedUser;
using Manipulae.Infrastructure.Service.YoutubeApi;
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
            services.AddScoped<IPasswordEncripter, PasswordEncripter>();
            services.AddScoped<ILoggedUser, LoggedUser>();
            services.AddScoped<IYoutubeService, YouTubeService>();

            AddToken(services, configuration);
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

            services.AddScoped<IUserDeleteRepository, UsersRepository>();
            services.AddScoped<IUserReadRepository, UsersRepository>();
            services.AddScoped<IUserUpdateRepository, UsersRepository>();
            services.AddScoped<IUserWriteRepository, UsersRepository>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = ConfigurationBinder.GetValue<uint>(configuration, "Settings:Jwt:ExpiresMinutes");
            var signingKey = ConfigurationBinder.GetValue<string>(configuration, "Settings:Jwt:SigningKey");

            services.AddScoped<IJwtTokenGenerator>(config => new JwtTokenGenetator(expirationTimeMinutes, signingKey!));
        }
    }
}
