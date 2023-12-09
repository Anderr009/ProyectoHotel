using Hotel.Web.Interface;
using Hotel.Web.Service;

namespace Hotel.Web.Dependencies
{
    public static class HttpClientDependencies
    {
        public static void addClientHttpDependency(this IServiceCollection service)
        {
            service.AddTransient<IClientHttpService, ClientHttpService>();
            service.AddTransient<IBaseRequestHttpClient, BaseHttpClient>();

        }
    }
}
