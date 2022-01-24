using Imi.Project.Mobile.Domain.Models.Api.Login;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiUserService : IUserService
    {
        public async Task<bool> Login(LoginRequest loginRequest)
        {
            return await WebApiClient.LoginCallApi(loginRequest);
        }
        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            return await WebApiClient.RegisterCallApi(registerRequest);
        }
        public bool Logout()
        {
            Application.Current.Properties["Token"] = "";
            return true;
        }
    }
}
