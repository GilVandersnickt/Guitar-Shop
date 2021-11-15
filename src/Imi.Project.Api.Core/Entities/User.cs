using Imi.Project.Api.Core.Entities.Base;
using Imi.Project.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class User : BaseUser
    {
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
    }
}
