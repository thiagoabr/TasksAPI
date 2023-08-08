using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Ports.Application;
using TasksAPI.Application.Services;
using TasksAPI.Domain.Ports.Data.Repositories;
using TasksAPI.Domain.Services;
using TasksAPI.Domain.Services.Interfaces;

namespace TasksAPI.Application.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskAppService, TaskAppService>();
            services.AddTransient<IUserAppService, UserAppService>();

            services.AddTransient<ITaskDomainService, TaskDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();

            return services;
        }
    }
}
