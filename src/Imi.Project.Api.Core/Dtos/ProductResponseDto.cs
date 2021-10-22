using System;

namespace Imi.Project.Api.Core.Dtos
{
    public class ProductResponseDto : DtoBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Uri Image { get; set; }
        public BrandResponseDto Brand { get; set; }
        public CategoryResponseDto Category { get; set; }
        public SubcategoryResponseDto Subcategory { get; set; }
    }
}
