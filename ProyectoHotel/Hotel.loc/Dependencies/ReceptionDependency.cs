using Hotel.application.Contracts;
using Hotel.application.Services;
using Hotel.infraestructure.Interfaces;
using Hotel.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Ioc.Dependencies
{
    public static class ReceptionDependency
    {
        public static void AddReceptionDependency(this IServiceCollection service) 
        {
            service.AddScoped<IReceptionRepository, ReceptionRepository>();
            service.AddTransient<IReceptionService, ReceptionService>();
        }
    }
}
