using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Imi.Project.Wpf.ApiModels.Login
{
    public class LoginApiResponse
    {
        [JsonPropertyName("jwtToken")]
        public string Token { get; set; }

    }
}
