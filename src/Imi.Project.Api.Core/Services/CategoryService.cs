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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IImageService imageService, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);
            var dto = _mapper.Map<CategoryResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<CategoryResponseDto>> ListAllAsync()
        {
            var result = await _categoryRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<CategoryResponseDto>>(result);
            return dto;
        }
        public async Task<IEnumerable<CategoryResponseDto>> GetByBrandIdAsync(Guid id)
        {
            var result = await _categoryRepository.GetByBrandIdAsync(id);
            var dto = _mapper.Map<IEnumerable<CategoryResponseDto>>(result);
            return dto;
        }

        public async Task<CategoryResponseDto> AddAsync(CategoryRequestDto categoryRequestDto)
        {
            var category = _mapper.Map<Category>(categoryRequestDto);

            if (category.Image == null)
            {
                category.Image = new Uri("https://via.placeholder.com/150/AFFAF0/000000?text=" + category.Name.Replace(" ", "+"), UriKind.Absolute);
            }

            var result = await _categoryRepository.AddAsync(category);
            var dto = _mapper.Map<CategoryResponseDto>(result);
            return dto;
        }

        public async Task<CategoryResponseDto> UpdateAsync(CategoryRequestDto categoryRequestDto)
        {
            var category = _mapper.Map<Category>(categoryRequestDto);
            var result = await _categoryRepository.UpdateAsync(category);
            var dto = _mapper.Map<CategoryResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return null;

            category.Image = await _imageService.AddOrUpdateImageAsync<Category>(id, image);
            await _categoryRepository.UpdateAsync(category);

            return await GetByIdAsync(id);
        }
    }
}
