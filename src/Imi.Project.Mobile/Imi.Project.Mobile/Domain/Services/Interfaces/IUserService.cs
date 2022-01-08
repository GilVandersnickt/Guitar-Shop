using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Login;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IUserService : ICrudService<User>
    {
        Task<bool> Login(LoginRequest loginRequest);
        Task Register(User user);
        Task Logout();
    }
}
