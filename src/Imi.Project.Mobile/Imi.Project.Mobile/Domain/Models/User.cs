using System;

namespace Imi.Project.Mobile.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }

    }
}
