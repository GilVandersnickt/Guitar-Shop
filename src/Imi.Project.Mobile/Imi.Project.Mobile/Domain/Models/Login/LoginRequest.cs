namespace Imi.Project.Mobile.Domain.Models.Login
{
    public class LoginRequest
    {
        //[JsonPropertyName("userName")]
        public string UserName { get; set; }

        //[JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
