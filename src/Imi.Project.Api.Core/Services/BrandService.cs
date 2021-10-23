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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IImageService imageService, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<BrandResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _brandRepository.GetByIdAsync(id);
            var dto = _mapper.Map<BrandResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<BrandResponseDto>> ListAllAsync()
        {
            var result = await _brandRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<BrandResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<BrandResponseDto>> GetByCategoryIdAsync(Guid id)
        {
            var result = await _brandRepository.GetByCategoryIdAsync(id);
            var dto = _mapper.Map<IEnumerable<BrandResponseDto>>(result);
            return dto;
        }
        public async Task<IEnumerable<BrandResponseDto>> GetBySubcategoryIdAsync(Guid id)
        {
            var result = await _brandRepository.GetBySubcategoryIdAsync(id);
            var dto = _mapper.Map<IEnumerable<BrandResponseDto>>(result);
            return dto;
        }

        public async Task<BrandResponseDto> AddAsync(BrandRequestDto brandRequestDto)
        {
            var brand = _mapper.Map<Brand>(brandRequestDto);

            if (brand.Image == null)
            {
                brand.Image = new Uri("https://via.placeholder.com/150/AFFAF0/000000?text=" + brand.Name.Replace(" ", "+"), UriKind.Absolute);
            }

            var result = await _brandRepository.AddAsync(brand);
            var dto = _mapper.Map<BrandResponseDto>(result);
            return dto;
        }

        public async Task<BrandResponseDto> UpdateAsync(BrandRequestDto brandRequestDto)
        {
            var brand = _mapper.Map<Brand>(brandRequestDto);
            var result = await _brandRepository.UpdateAsync(brand);
            var dto = _mapper.Map<BrandResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _brandRepository.DeleteAsync(id);
        }

        public async Task<BrandResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                return null;

            brand.Image = await _imageService.AddOrUpdateImageAsync<Brand>(id, image);
            await _brandRepository.UpdateAsync(brand);

            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<BrandResponseDto>> SearchAsync(string name)
        {
            var brands = await _brandRepository.SearchAsync(name);
            return _mapper.Map<IEnumerable<BrandResponseDto>>(brands);
        }
    }
}
