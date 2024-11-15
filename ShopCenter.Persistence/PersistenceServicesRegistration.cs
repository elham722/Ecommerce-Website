using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Persistence.Context;
using ShopCenter.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ShopCenterDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ShopCenterConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
