using Hotel.application.Contracts;
using Hotel.application.Services;
using Hotel.infraestructure.Interfaces;
using Hotel.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Ioc.Dependencia
{
    public static class FloorDependency
    {
        public static void AddFloorDependecy(this IServiceCollection service)
        {
            service.AddScoped<IFloorRepository, FloorRepository>();
            service.AddTransient<IFloorService, FloorService>();
        }
    }
}
