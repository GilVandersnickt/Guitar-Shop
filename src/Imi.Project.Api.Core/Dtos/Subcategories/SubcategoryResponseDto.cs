using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Categories;
using Imi.Project.Api.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Subcategories
{
    public class SubcategoryResponseDto : BaseDto
    {
        public string Name { get; set; }
        public CategoryResponseDto Category { get; set; }
        public List<ProductResponseDto> Products { get; set; }
        public List<BrandResponseDto> Brands { get; set; }
    }
}
