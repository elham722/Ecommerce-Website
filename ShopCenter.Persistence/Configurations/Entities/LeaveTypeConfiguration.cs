using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "Vacations",
                    Password = "Elh@m3605",
                    CreateDate = DateTime.Now,
                },
                new User
                {
                    Id=2,
                    UserName="Eli",
                    Password="123456",
                    CreateDate = DateTime.Now,
                  
                });
        }
    }
}
