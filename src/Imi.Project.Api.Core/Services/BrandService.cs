using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
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

    }
}
