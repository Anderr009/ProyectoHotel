
using Hotel.application.Contracts;
using Hotel.application.Service;
using Hotel.infraestructure.Interfaces;
using Hotel.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Hotel.Ioc.Dependencies
{
    public static class RoomDependency
    {
        public static void AddRoomDependency(this IServiceCollection service)
        {
            service.AddScoped<IRoomRepository, RoomRepository>();
            service.AddTransient<IRoomService, RoomService>();

        }

  
    }
}
