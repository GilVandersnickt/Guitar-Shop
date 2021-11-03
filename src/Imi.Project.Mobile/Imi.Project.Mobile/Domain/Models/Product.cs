using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubcategoryId { get; set; }

    }
}
