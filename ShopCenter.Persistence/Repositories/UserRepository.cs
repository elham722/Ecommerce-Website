using Microsoft.EntityFrameworkCore;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Domain.Entities;
using ShopCenter.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly ShopCenterDbContext _dbContext;

        public UserRepository(ShopCenterDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetListUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
    }
}
