using System.Collections.Generic;
using System.IO;

namespace Imi.Project.Blazor.Models.Api
{
    public class ProductRequestForm : ProductRequest
    {
        public decimal PriceDecimal { get; set; }
        public List<BrandResponse> Brands { get; set; }
        public List<CategoryResponse> Categories { get; set; }
        public List<SubcategoryResponse> Subcategories { get; set; }
        public Stream ImageInputFile { get; set; }
    }
}
