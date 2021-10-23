using Imi.Project.Api.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<Uri> AddOrUpdateImageAsync<T>(Guid id, IFormFile image) where T : BaseEntity;
    }
}
