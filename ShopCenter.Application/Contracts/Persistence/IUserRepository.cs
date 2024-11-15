using ShopCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetListUsers();
        Task<User> GetUserById(int id);
    }
}
