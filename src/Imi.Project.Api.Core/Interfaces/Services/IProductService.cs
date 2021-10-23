using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetByBrandIdAsync(Guid id);
        Task<IEnumerable<ProductResponseDto>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<ProductResponseDto>> GetBySubcategoryIdAsync(Guid id);

        Task<IEnumerable<ProductResponseDto>> ListAllAsync();
        Task<ProductResponseDto> GetByIdAsync(Guid id);
        Task<ProductResponseDto> AddAsync(ProductRequestDto productRequestDto);
        Task<ProductResponseDto> UpdateAsync(ProductRequestDto productRequestDto);
        Task DeleteAsync(Guid id);
    }
}
