using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos
{
    public class BrandResponseDto : DtoBase
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }
        public ICollection<CategoryResponseDto> Categories { get; set; }
        public ICollection<SubcategoryResponseDto> Subcategories { get; set; }
    }
}
