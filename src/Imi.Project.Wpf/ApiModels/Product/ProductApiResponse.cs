using Imi.Project.Wpf.ApiModels.Base;
using Imi.Project.Wpf.ApiModels.Brand;
using Imi.Project.Wpf.ApiModels.Category;
using Imi.Project.Wpf.ApiModels.Subcategory;
using System;
using System.Text.Json.Serialization;

namespace Imi.Project.Wpf.ApiModels.Product
{
    public class ProductApiResponse : BaseApiResponse
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("image")]
        public Uri Image { get; set; }

        [JsonPropertyName("brand")]
        public BrandApiResponse Brand { get; set; }

        [JsonPropertyName("category")]
        public CategoryApiResponse Category { get; set; }

        [JsonPropertyName("subcategory")]
        public SubcategoryApiResponse Subcategory { get; set; }
    }
}
