
using Hotel.web.Interface;
using Hotel.web.Service;

namespace Hotel.web.Dependencies
{
    public static class HttpRoomDependencies
    {
        public static void AddRoomHttpDependency(this IServiceCollection service)
        {

                 
            service.AddTransient<IRoomHttpService, RoomHttpService>();
            service.AddTransient<IBaseRequestHttpClient, BaseHttpClient>();


           
        }
    }
}
