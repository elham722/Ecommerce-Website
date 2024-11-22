using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using ShopCenter.MVC.Contracts;
using ShopCenter.MVC.Services.Base;

namespace ShopCenter.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthenticateService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor)
            : base(client, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticateRequest = new()
                {
                    Email = email,
                    Password = password
                };
                var authenticateResponse = await _client.LoginAsync(authenticateRequest);
                if (authenticateResponse.Token != string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticateResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorage.SetStorageValue("token", authenticateResponse.Token);

                    return true;
                }

                return false;


            }
            catch
            {

                return false;
            }
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string>() { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(string firstName, string lastName, string email, string password)
        {
            RegisterationRequest registrationRequest = new()
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
            };
            var response = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }

            return false;

        }

        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }
    }
}
