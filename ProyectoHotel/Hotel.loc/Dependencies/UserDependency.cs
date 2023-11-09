using Hotel.application.Contract;
using Hotel.application.Service;
using Hotel.infraestructure.Repositories;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Ioc.Dependencies
{
    public static class UserDependency
    {
        public static void AddUserDependency(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}
