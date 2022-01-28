using Imi.Project.Api.Core.Entities.Base;
using System;

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
