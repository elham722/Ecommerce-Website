using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopCenter.Application.Contracts.Infrastructure;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Application.Models;
using ShopCenter.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Infrastructure
{
    public static class InfrastractureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {
           services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
