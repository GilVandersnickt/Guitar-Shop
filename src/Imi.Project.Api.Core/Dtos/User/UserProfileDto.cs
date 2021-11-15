using System;

namespace Imi.Project.Api.Core.Dtos.User
{
    public class UserProfileDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
    }
}