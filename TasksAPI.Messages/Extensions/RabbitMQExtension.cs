using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Ports.Messages.Producers;
using TasksAPI.Messages.Managers;
using TasksAPI.Messages.Producers;
using TasksAPI.Messages.Settings;

namespace TasksAPI.Messages.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));
            services.AddTransient<ITaskMessageProducer, TaskMessageProducer>();
            services.AddTransient<RabbitMQManager>();

            return services;
        }
    }
}
