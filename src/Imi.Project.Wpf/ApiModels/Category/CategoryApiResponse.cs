using Imi.Project.Wpf.ApiModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.Wpf.ApiModels.Category
{
    public class CategoryApiResponse : BaseApiResponse
    {
        [JsonPropertyName("image")]
        public Uri Image { get; set; }
    }
}
