using Imi.Project.Wpf.ApiModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.Wpf.ApiModels.Brand
{
    public class BrandApiResponse : BaseApiResponse
    {
        [JsonPropertyName("image")]
        public Uri Image { get; set; }
    }
}
