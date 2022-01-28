using System;

namespace Imi.Project.Mobile.Domain.Models.Api
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public Uri Image { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubcategoryId { get; set; }
    }
}
