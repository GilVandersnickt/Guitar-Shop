using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Entities
{
    public class BrandCategory
    {
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}
