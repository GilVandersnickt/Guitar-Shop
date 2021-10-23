using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Dtos.Brands;
using Imi.Project.Api.Core.Dtos.Categories;
using Imi.Project.Api.Core.Dtos.Subcategories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos.Products
{
    public class ProductResponseDto : BaseDto
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public decimal Price { get; set; }
        public CategoryResponseDto Category { get; set; }
        public SubcategoryResponseDto Subcategory { get; set; }
        public BrandResponseDto Brand { get; set; }
    }
}
