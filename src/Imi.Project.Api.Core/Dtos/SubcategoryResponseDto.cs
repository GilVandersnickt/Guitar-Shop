using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos
{
    public class SubcategoryResponseDto : DtoBase
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public string Category { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }
        public ICollection<BrandResponseDto> Brands { get; set; }
    }
}
