using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public async Task<SubcategoryResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _subcategoryRepository.GetByIdAsync(id);
            var dto = _mapper.Map<SubcategoryResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<SubcategoryResponseDto>> ListAllAsync()
        {
            var result = await _subcategoryRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<SubcategoryResponseDto>>(result);
            return dto;
        }
        public async Task<IEnumerable<SubcategoryResponseDto>> GetByBrandIdAsync(Guid id)
        {
            var result = await _subcategoryRepository.GetByBrandIdAsync(id);
            var dto = _mapper.Map<IEnumerable<SubcategoryResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<SubcategoryResponseDto>> GetByCategoryIdAsync(Guid id)
        {
            var result = await _subcategoryRepository.GetByCategoryIdAsync(id);
            var dto = _mapper.Map<IEnumerable<SubcategoryResponseDto>>(result);
            return dto;
        }

        public async Task<SubcategoryResponseDto> AddAsync(SubcategoryRequestDto subcategoryRequestDto)
        {
            var subcategory = _mapper.Map<Subcategory>(subcategoryRequestDto);

            var result = await _subcategoryRepository.AddAsync(subcategory);
            var dto = _mapper.Map<SubcategoryResponseDto>(result);
            return dto;
        }

        public async Task<SubcategoryResponseDto> UpdateAsync(SubcategoryRequestDto subcategoryRequestDto)
        {
            var subcategory = _mapper.Map<Subcategory>(subcategoryRequestDto);
            var result = await _subcategoryRepository.UpdateAsync(subcategory);
            var dto = _mapper.Map<SubcategoryResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _subcategoryRepository.DeleteAsync(id);
        }
    }
}
