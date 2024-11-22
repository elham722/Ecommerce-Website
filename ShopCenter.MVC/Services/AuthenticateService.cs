using System.IdentityModel.Tokens.Jwt;
using ShopCenter.MVC.Contracts;
using ShopCenter.MVC.Services.Base;

namespace ShopCenter.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthenticateService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor ) 
            : base(client, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public Task<bool> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(string firstName, string lastName, string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
