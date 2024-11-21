using AutoMapper;
using ShopCenter.MVC.Contracts;
using ShopCenter.MVC.Models;
using ShopCenter.MVC.Services.Base;

namespace ShopCenter.MVC.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public UserService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage) : base(httpClient, localStorage)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateUser(UserVM user)
        {
            try
            {
                var response = new Response<int>();
                CreateUserDto createUserDto = _mapper.Map<CreateUserDto>(user);

                //to do auth

                var apiRespose = await _httpClient.UsersPOSTAsync(createUserDto);

                if (apiRespose.Success)
                {
                    response.Date = apiRespose.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var err in response.ValidationErrors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public Task DeleteUser(UserVM user)
        {
            throw new NotImplementedException();
        }

        public Task<UserVM> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserVM>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserVM user)
        {
            throw new NotImplementedException();
        }
    }
}
