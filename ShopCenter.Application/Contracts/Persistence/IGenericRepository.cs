using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>>  GetAll();
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Add(T entity);
        Task<bool> Exist(int id);

    }
}
