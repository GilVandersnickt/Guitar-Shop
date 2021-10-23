using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISubcategoryService
    {
        Task<IEnumerable<SubcategoryResponseDto>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<SubcategoryResponseDto>> GetByCategoryIdAsync(Guid id);

        Task<IEnumerable<SubcategoryResponseDto>> ListAllAsync();
        Task<SubcategoryResponseDto> GetByIdAsync(Guid id);
        Task<SubcategoryResponseDto> AddAsync(SubcategoryRequestDto subcategoryRequestDto);
        Task<SubcategoryResponseDto> UpdateAsync(SubcategoryRequestDto subcategoryRequestDto);
        Task DeleteAsync(Guid id);
    }
}
