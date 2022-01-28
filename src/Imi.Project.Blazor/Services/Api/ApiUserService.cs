using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api.Login;
using Imi.Project.Blazor.Services.Interfaces;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class ApiUserService : IUserService
    {
        public async Task<bool> Login(string username, string password)
        {
            LoginRequest request = new LoginRequest { UserName = username, Password = password };

            return await WebApiClient.LoginCallApi(request);
        }
        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            return await WebApiClient.RegisterCallApi(registerRequest);
        }
        public bool Logout()
        {
            ApiSettings.Token = string.Empty;
            return true;
        }
    }
}
