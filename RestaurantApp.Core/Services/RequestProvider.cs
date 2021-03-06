﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
    public class RequestProvider : IRequestProvider
    {
        private readonly AppInfo _appInfo;
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings

            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
              
               
            
            };
        }

        public string AccessToken { get; set; }


        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.GetAsync(uri);

            await HandleResponse(response);

            var serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));


            return result;
        }


        public Task<TResult> PostAsync<TResult>(string uri, TResult data)

        {
            return PostAsync<TResult, TResult>(uri, data);
        }


        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            var httpClient = CreateHttpClient();
            var serialized = JsonConvert.SerializeObject(data, _serializerSettings);
            var response = await httpClient.PostAsync(uri,
                new StringContent(serialized, Encoding.UTF8, "application/json"));
            await HandleResponse(response);
            var responseData = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            return PutAsync<TResult, TResult>(uri, data);
        }


        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            var httpClient = CreateHttpClient();

            var serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            var response = await httpClient.PutAsync(uri,
                new StringContent(serialized, Encoding.UTF8, "application/json"));
            await HandleResponse(response);
            var responseData = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }


        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AccessToken);
            }
            return httpClient;
        }


        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();


                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new ServiceAuthenticationException(content);

                throw new HttpRequestException(content);
            }
        }
    }
}