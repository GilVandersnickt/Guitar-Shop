using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Categories;
using Imi.Project.Api.Core.Dtos.Products;
using Imi.Project.Api.Core.Dtos.Subcategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Brands
{
    public class BrandResponseDto : BaseDto
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public List<ProductResponseDto> Products { get; set; }
        public List<CategoryResponseDto> Categories { get; set; }
        public List<SubcategoryResponseDto> Subcategories { get; set; }
    }
}
