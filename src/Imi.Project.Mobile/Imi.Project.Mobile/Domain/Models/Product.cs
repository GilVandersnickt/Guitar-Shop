using Imi.Project.Mobile.Domain.Models.Api.Default;
using System;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DefaultModelWithImage Brand { get; set; }
        public DefaultModelWithImage Category { get; set; }
        public DefaultModel Subcategory { get; set; }
    }
}
