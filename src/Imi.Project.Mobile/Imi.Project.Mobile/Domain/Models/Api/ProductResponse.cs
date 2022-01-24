using Imi.Project.Mobile.Domain.Models.Api.Default;
using System;
using System.Text.Json.Serialization;

namespace Imi.Project.Mobile.Domain.Models.Api
{
    public class ProductResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("image")]
        public Uri Image { get; set; }

        [JsonPropertyName("brand")]
        public DefaultModelWithImage Brand { get; set; }

        [JsonPropertyName("category")]
        public DefaultModelWithImage Category { get; set; }

        [JsonPropertyName("subcategory")]
        public DefaultModel Subcategory { get; set; }
    }
}
