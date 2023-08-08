using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Security;

namespace TasksAPI.Application.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services, IConfiguration configuration) 
        {
            var settings = "JwtBearerSettings";

            var issuer = configuration.GetSection($"{settings}:Issuer").Value;
            var audience = configuration.GetSection($"{settings}:Audience").Value;
            var secretKey = configuration.GetSection($"{settings}:SecretKey").Value;
            var expirationInMinutes = int.Parse(configuration.GetSection($"{settings}:ExpirationInMinutes").Value);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, 
                        ValidateAudience = true, 
                        ValidateLifetime = true, 
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer, 
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.Configure<JwtBearerSettings>(configuration.GetSection(settings));
            services.AddTransient<JwtTokenCreator>();

            return services;
        }
    }
}
