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
    public static class RolUserDependency
    {
        public static void AddRolUserDependecy(this IServiceCollection service)
        {
            service.AddScoped<IRolUserRepository, RolUserRepository>();
            service.AddTransient<IRolUserService, RolUserService>();
        }
    }
}