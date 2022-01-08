using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Login;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiUserService : IUserService
    {
        public async Task<bool> Login(LoginRequest loginRequest)
        {
            return await WebApiClient.LoginCallApi(loginRequest);
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task Register(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<User> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
