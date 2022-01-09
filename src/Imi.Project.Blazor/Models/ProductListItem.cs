using System;

namespace Imi.Project.Blazor.Models
{
    public class ProductListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
