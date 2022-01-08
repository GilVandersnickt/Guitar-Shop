using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models.Api;
using Imi.Project.Mobile.Domain.Models.Login;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class WebApiClient
    {
        private static HttpClientHandler ClientHandler()
        {
            var httpClientHandler = new HttpClientHandler();
#if DEBUG
            //allow connecting to untrusted certificates when running a DEBUG assembly
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
#endif
            return httpClientHandler;
        }
        private static JsonMediaTypeFormatter GetJsonFormatter()
        {
            var formatter = new JsonMediaTypeFormatter();
            //prevent self-referencing loops when saving Json (Bucket -> BucketItem -> Bucket -> ...)
            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return formatter;
        }
        public static async Task<T> GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                string response = await httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<T>(response, GetJsonFormatter().SerializerSettings);
            }
        }
        public static async Task<TOut> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }
        public static async Task<TOut> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }
        public static async Task<TOut> DeleteCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }
        private static async Task<TOut> CallApi<TOut, TIn>(string uri, TIn entity, HttpMethod httpMethod)
        {
            TOut result = default;

            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                if (Application.Current.Properties["Token"] != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["Token"] as string);

                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    var content = JsonConvert.SerializeObject(entity);
                    var stringContent = new StringContent(content);
                    stringContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                    response = await httpClient.PostAsync(uri, stringContent);
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    response = await httpClient.PutAsync(uri, entity, GetJsonFormatter());
                }
                else
                {
                    response = await httpClient.DeleteAsync(uri);
                }
                result = await response.Content.ReadAsAsync<TOut>();
            }
            return result;
        }
        public static async Task<bool> LoginCallApi(LoginRequest request)
        {
            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                httpClient.BaseAddress = new Uri(ApiSettings.BaseUri);

                var response = await httpClient.PostAsync("auth/login", request, GetJsonFormatter());

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);
                    Application.Current.Properties["Token"] = loginResponse.jwtToken;
                }
                return response.IsSuccessStatusCode;
            }
        }
    }
}
