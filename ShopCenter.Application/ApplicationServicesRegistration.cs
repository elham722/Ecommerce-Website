using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopCenter.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           // services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
