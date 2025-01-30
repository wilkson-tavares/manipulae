using Manipulae.Application.AutoMapper;
using Manipulae.Application.UseCases.Login;
using Manipulae.Application.UseCases.Users.ChangePassword;
using Manipulae.Application.UseCases.Users.Delete;
using Manipulae.Application.UseCases.Users.Profile;
using Manipulae.Application.UseCases.Users.Register;
using Manipulae.Application.UseCases.Users.Update;
using Manipulae.Application.UseCases.Videos.Delete;
using Manipulae.Application.UseCases.Videos.Filter;
using Manipulae.Application.UseCases.Videos.GetById;
using Manipulae.Application.UseCases.Videos.Register;
using Manipulae.Application.UseCases.Videos.Update;
using Manipulae.Application.UseCases.Youtube;
using Microsoft.Extensions.DependencyInjection;

namespace Manipulae.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        #region Services
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {

            services.AddScoped<IDeleteVideoUseCase, DeleteVideoUseCase>();
            services.AddScoped<IRegisterVideoUseCase, RegisterVideoUseCase>();
            services.AddScoped<IFilterVideoUseCase, FilterVideoUseCase>();
            services.AddScoped<IUpdateVideoUseCase, UpdateVideoUseCase>();
            services.AddScoped<IGetVideoByIdUseCase, GetVideoByIdUseCase>();
            
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
            services.AddScoped<IDeleteUserAccountUseCase, DeleteUserAccountUseCase>();
            
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();

            services.AddScoped<IYoutubeUseCase, YoutubeUseCase>();
        }
        #endregion
    }
}
