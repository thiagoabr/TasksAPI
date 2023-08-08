using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Data.Contexts;
using TasksAPI.Data.Repositories;
using TasksAPI.Domain.Ports.Data.Repositories;

namespace TasksAPI.Data.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BDTasksAPI");

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
