using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBrandService 
    {
        Task<IEnumerable<BrandResponseDto>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<BrandResponseDto>> GetBySubcategoryIdAsync(Guid id);

        Task<IEnumerable<BrandResponseDto>> ListAllAsync();
        Task<BrandResponseDto> GetByIdAsync(Guid id);
        Task<BrandResponseDto> AddAsync(BrandRequestDto brandRequestDto);
        Task<BrandResponseDto> UpdateAsync(BrandRequestDto brandRequestDto);
        Task DeleteAsync(Guid id);
    }
}
