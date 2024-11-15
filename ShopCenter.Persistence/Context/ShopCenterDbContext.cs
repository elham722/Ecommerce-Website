using Microsoft.EntityFrameworkCore;
using ShopCenter.Domain.Entities;
using ShopCenter.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Persistence.Context
{
    public class ShopCenterDbContext : DbContext
    {
        public ShopCenterDbContext(DbContextOptions<ShopCenterDbContext> options)
            :base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ShopCenterDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.CreateDate = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate= DateTime.Now;
                }
            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
