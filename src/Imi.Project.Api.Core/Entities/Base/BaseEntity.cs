using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        [Required] 
        public DateTime CreatedOn { get; set; }
        [Required] 
        public DateTime LastEditedOn { get; set; }
    }
}
