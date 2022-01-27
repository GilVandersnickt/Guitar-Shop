using System;

namespace Imi.Project.Blazor.Models.Api
{
    public class BrandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Image { get; set; }
    }
}
