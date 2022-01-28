using Imi.Project.Api.Core.Dtos.Default;
using System;

namespace Imi.Project.Api.Core.Dtos
{
    public class ProductResponseDto : DtoBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Uri Image { get; set; }
        public DefaultWithImageResponseDto Brand { get; set; }
        public DefaultWithImageResponseDto Category { get; set; }
        public DefaultResponseDto Subcategory { get; set; }
    }
}
