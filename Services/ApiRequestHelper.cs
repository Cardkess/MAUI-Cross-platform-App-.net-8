using MAUI.Enums;
using System.Net.Http.Json;
using System.Text.Json;

namespace MAUI.Services
{
    public interface IApiRequestHelper
    {
        Task<T> GetAsync<T>(ApiNames api, string relativePath, CancellationToken cancellationToken = default);
        Task<T> SendAsync<T>(HttpMethod httpMethod, ApiNames api, string relativePath,
            object requestData = null, CancellationToken cancellationToken = default);
    }

    public class ApiRequestHelper : IApiRequestHelper
    {

        readonly IHttpClientFactory _httpClientFactory;

        public ApiRequestHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>(ApiNames api, string relativePath, CancellationToken cancellationToken = default)
        {
            var client = GetHttpClient(api);

            relativePath = relativePath.TrimStart('/');

            var resp = await client.GetAsync(relativePath, cancellationToken);

            if (resp.IsSuccessStatusCode)
            {
                // Create custom 'JsonSerializerOptions' instance if needed
                var options = new JsonSerializerOptions();

                return await resp.Content.ReadFromJsonAsync<T>();
            }

            return default;
        }


        public async Task<T> SendAsync<T>(HttpMethod httpMethod, ApiNames api, string relativePath, object requestData = null, CancellationToken cancellationToken = default)
        {
            var client = GetHttpClient(api);

            relativePath = relativePath.TrimStart('/');

            var request = new HttpRequestMessage(httpMethod, relativePath);

            if (requestData != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");
            }

            var resp = await client.SendAsync(request, cancellationToken);

            if (resp.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions()
                {
                    // Add custom JSON serialization settings if needed
                };

                return await resp.Content.ReadFromJsonAsync<T>();
            }

            return default;
        }


        HttpClient GetHttpClient(ApiNames api)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient(api.ToString());

            // add headers

            return httpClient;
        }
    }
}
