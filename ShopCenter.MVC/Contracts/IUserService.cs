using ShopCenter.MVC.Models;
using ShopCenter.MVC.Services.Base;

namespace ShopCenter.MVC.Contracts
{
    public interface IUserService
    {
        Task<List<UserVM>> GetUsers();
        Task<UserVM> GetUser(int id);
        Task<Response<int>> CreateUser(UserVM user);
        Task UpdateUser(UserVM user);
        Task DeleteUser(UserVM user);
    }
}
