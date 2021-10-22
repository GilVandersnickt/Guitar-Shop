using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            var dto = _mapper.Map<ProductResponseDto>(result);
            return dto;
        }
        public async Task<IEnumerable<ProductResponseDto>> ListAllAsync()
        {
            var result = await _productRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
            return dto;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetByBrandIdAsync(Guid id)
        {
            var result = await _productRepository.GetByBrandIdAsync(id);
            var dto = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
            return dto;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetByCategoryIdAsync(Guid id)
        {
            var result = await _productRepository.GetByCategoryIdAsync(id);
            var dto = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
            return dto;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetBySubcategoryIdAsync(Guid id)
        {
            var result = await _productRepository.GetBySubcategoryIdAsync(id);
            var dto = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
            return dto;
        }
    }
}
