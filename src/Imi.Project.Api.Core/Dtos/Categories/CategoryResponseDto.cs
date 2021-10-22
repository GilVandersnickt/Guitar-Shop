using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Products;
using Imi.Project.Api.Core.Dtos.Subcategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Categories
{
    public class CategoryResponseDto : BaseDto
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public List<ProductResponseDto> Products { get; set; }
        public List<SubcategoryResponseDto> Subcategories { get; set; }
        public List<BrandResponseDto> Brands { get; set; }
    }
}
