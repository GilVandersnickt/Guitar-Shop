using Imi.Project.Api.Core.Dtos.Partials;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Dtos
{
    public class SubcategoryResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }
        public ICollection<DefaultResponseDto> Brands { get; set; }
    }
}
