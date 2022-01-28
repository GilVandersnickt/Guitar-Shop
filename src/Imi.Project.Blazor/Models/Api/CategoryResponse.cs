using System;

namespace Imi.Project.Blazor.Models.Api
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Image { get; set; }
    }
}
