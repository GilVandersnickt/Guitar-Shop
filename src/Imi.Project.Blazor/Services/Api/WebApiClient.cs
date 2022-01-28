﻿using Imi.Project.Blazor.Constants;
using Imi.Project.Blazor.Models.Api.Login;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
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
                if (ApiSettings.Token != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiSettings.Token);

                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsync(uri, entity, GetJsonFormatter());
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
        public static async Task<bool> UploadImage(Guid id, Stream stream, string apiEndpoint)
        {
            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Headers.ContentType.MediaType = "multipart/form-data";
                    content.Add(new StreamContent(stream), "image", $"{id}.png");

                    if (ApiSettings.Token != null)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiSettings.Token);
                    var response = await httpClient.PutAsync(apiEndpoint, content);
                    return response.IsSuccessStatusCode;
                }
            }
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


                    ApiSettings.Token = loginResponse.jwtToken;
                }
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> RegisterCallApi(RegisterRequest request)
        {
            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                httpClient.BaseAddress = new Uri(ApiSettings.BaseUri);
                HttpResponseMessage response;

                response = await httpClient.PostAsync("auth/register", request, GetJsonFormatter());

                var responseString = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
        }

    }
}
