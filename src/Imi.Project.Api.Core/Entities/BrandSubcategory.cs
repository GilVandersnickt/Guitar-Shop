using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Entities
{
    public class BrandSubcategory
    {
        public Guid BrandId { get; set; }
        public Guid SubcategoryId { get; set; }
        public Brand Brand { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
