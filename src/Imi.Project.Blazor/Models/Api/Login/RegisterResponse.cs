using System.Collections.Generic;

namespace Imi.Project.Blazor.Models.Api.Login
{
    public class RegisterResponse
    {
        public bool Succeeded { get; set; }
        public ICollection<string> ErrorMessages { get; set; }
    }
}
