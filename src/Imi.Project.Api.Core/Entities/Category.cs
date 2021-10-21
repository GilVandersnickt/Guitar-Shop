﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Uri Image { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<BrandCategory> Brands { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
