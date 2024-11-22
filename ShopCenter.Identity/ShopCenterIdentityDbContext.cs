using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopCenter.Identity.Configurations;
using ShopCenter.Identity.Models;

namespace ShopCenter.Identity
{
    public class ShopCenterIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopCenterIdentityDbContext(DbContextOptions<ShopCenterIdentityDbContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
