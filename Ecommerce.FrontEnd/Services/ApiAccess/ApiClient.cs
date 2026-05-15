using System.Net.Http.Json;

namespace Ecommerce.FrontEnd.Services.ApiAccess
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            return await httpClient.GetFromJsonAsync<T>(url);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var response = await httpClient.PostAsJsonAsync(url, data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

    }
}
