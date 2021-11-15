using Imi.Project.Api.Core.Dtos.User;
using Imi.Project.Api.Core.Services.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService 
    {
        Task<LoginResult> LoginAsync(LoginRequestDto loginCredentials);
        Task<RegisterResult> RegisterAsync(RegisterUserRequestDto registerModel);
        Task<UserProfileDto> GetCurrentUserProfileAsync();
        Task<DeleteResult> DeleteAsync(Guid id);

    }
}
