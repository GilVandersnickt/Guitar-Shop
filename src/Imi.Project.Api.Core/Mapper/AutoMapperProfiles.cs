using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Default;
using Imi.Project.Api.Entities;
using System.Linq;

namespace Imi.Project.Api.Core.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Brand, BrandResponseDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.BrandCategories
                .Select(bc => new DefaultResponseDto { Id = bc.CategoryId, Name = bc.Category.Name })))
                .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.BrandSubcategories
                .Select(bc => new DefaultResponseDto { Id = bc.SubcategoryId, Name = bc.Subcategory.Name })));


            CreateMap<Category, CategoryResponseDto>()
                .ForMember(dest => dest.Brands, opt => opt.MapFrom(src => src.BrandCategories
                .Select(bc => new DefaultResponseDto { Id = bc.BrandId, Name = bc.Brand.Name })))
                .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.Subcategories
                .Select(c => new DefaultResponseDto { Id = c.Id, Name = c.Name })));

            CreateMap<Subcategory, SubcategoryResponseDto>()
                .ForMember(dest => dest.Brands, opt => opt.MapFrom(src => src.BrandSubcategories
                .Select(bs => new DefaultResponseDto { Id = bs.BrandId, Name = bs.Brand.Name })))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => new DefaultWithImageResponseDto { Id = src.Brand.Id, Name = src.Brand.Name, Image = src.Brand.Image }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new DefaultWithImageResponseDto { Id = src.Category.Id, Name = src.Category.Name, Image = src.Category.Image }))
                .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => new DefaultResponseDto { Id = src.Subcategory.Id, Name = src.Subcategory.Name }));

            CreateMap<BrandRequestDto, Brand>();
            CreateMap<CategoryRequestDto, Category>();
            CreateMap<SubcategoryRequestDto, Subcategory>();
            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => decimal.Parse(src.Price)));
        }
    }
}
