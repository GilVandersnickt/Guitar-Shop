using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Subcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
