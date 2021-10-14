﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Entities
{
    public class Subcategory : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<BrandsSubcategories> Brands { get; set; }
    }
}
