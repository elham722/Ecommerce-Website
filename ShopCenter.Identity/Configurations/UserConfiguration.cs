using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCenter.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "0ed66cfa-39ac-4dba-a6a3-1492b5b748b2",
                    Email="elham.heydari722@gmail.com",
                    NormalizedEmail= "elham.heydari722@gmail.com",
                    FirstName="eli",
                    LastName="heydari",
                    UserName="elikhanom",
                    NormalizedUserName= "elham.heydari722@gmail.com",
                    PasswordHash=hasher.HashPassword(null,"Elham3605"),
                    EmailConfirmed=true,
                });
        }
    }
}
