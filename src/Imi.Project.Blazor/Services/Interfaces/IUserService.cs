using Imi.Project.Blazor.Models.Api.Login;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Login(string username, string password);
        Task<bool> Register(RegisterRequest registerRequest);
        bool Logout();
    }
}
