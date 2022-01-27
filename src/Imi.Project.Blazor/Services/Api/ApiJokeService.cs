using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api.Joke;
using Imi.Project.Blazor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class ApiJokeService : IJokeService
    {
        public async Task<string> GetRandomJoke()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(JokeSettings.JokeUri),
                Headers = {
                    { "x-rapidapi-host", JokeSettings.JokeHost },
                    { "x-rapidapi-key", JokeSettings.JokeKey }
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jokeResponse = JsonConvert.DeserializeObject<JokeResponse>(body);

                return jokeResponse.joke;
            }
        }
    }
}
