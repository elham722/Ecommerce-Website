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

        public async Task<Response<int>> CreateUser(CreateUserVM user)
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
                    foreach (var err in response.ValidationErrors)
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

        public async Task<Response<int>> DeleteUser(int id)
        {
            try
            {
                await _httpClient.UsersDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<UserVM> GetUser(int id)
        {
            var user = await _httpClient.UsersGETAsync(id);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<List<UserVM>> GetUsers()
        {
            var users = await _httpClient.UsersAllAsync();
            return _mapper.Map<List<UserVM>>(users);
        }

        public async Task<Response<int>> UpdateUser(int id,UserVM user)
        {
            try
            {
                UserDTO userDto = _mapper.Map<UserDTO>(user);
                await _httpClient.UsersPUTAsync(id,userDto.ToString());
                return new Response<int> {Success = true};
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
