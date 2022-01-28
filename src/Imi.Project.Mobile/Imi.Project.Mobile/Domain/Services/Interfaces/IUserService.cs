using Imi.Project.Mobile.Domain.Models.Api.Login;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Login(LoginRequest loginRequest);
        Task<bool> Register(RegisterRequest registerRequest);
        bool Logout();
    }
}
