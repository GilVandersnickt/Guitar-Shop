using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IImageService imageService, IMapper mapper)
        {
            _productRepository = productRepository;
            _imageService = imageService;
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

        public async Task<ProductResponseDto> AddAsync(ProductRequestDto productRequestDto)
        {
            var product = _mapper.Map<Product>(productRequestDto);

            if (product.Image == null)
            {
                product.Image = new Uri("https://via.placeholder.com/150/AFFAF0/000000?text=" + product.Name.Replace(" ", "+"), UriKind.Absolute);
            }

            var result = await _productRepository.AddAsync(product);
            var dto = _mapper.Map<ProductResponseDto>(result);
            return dto;
        }

        public async Task<ProductResponseDto> UpdateAsync(ProductRequestDto productRequestDto)
        {
            var product = _mapper.Map<Product>(productRequestDto);
            var result = await _productRepository.UpdateAsync(product);
            var dto = _mapper.Map<ProductResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image) 
        { 
            var product = await _productRepository.GetByIdAsync(id); 
            if (product == null) 
                return null; 

            product.Image = await _imageService.AddOrUpdateImageAsync<Product>(id, image); 
            await _productRepository.UpdateAsync(product); 

            return await GetByIdAsync(id); 
        }

        public async Task<IEnumerable<ProductResponseDto>> SearchAsync(string name)
        {
            var products = await _productRepository.SearchAsync(name);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

    }
}
