using System;

namespace Imi.Project.Api.Core.Dtos
{
    public class ProductResponseDto : DtoBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Uri Image { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
    }
}
