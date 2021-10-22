using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> ListAllAsync();
        Task<CategoryResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoryResponseDto>> GetByBrandIdAsync(Guid id);
    }
}
