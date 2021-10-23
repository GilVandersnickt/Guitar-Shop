using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos
{
    public class CategoryResponseDto : DtoBase
    {
        public string Name { get; set; }
        public Uri Image { get; set; }
        public List<string> Brands { get; set; }
        public List<string> Subcategories { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }
    }
}
