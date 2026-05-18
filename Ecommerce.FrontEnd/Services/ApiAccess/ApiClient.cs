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
            return await httpClient.GetFromJsonAsync<T>("http://localhost:5130/" + url);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var response = await httpClient.PostAsJsonAsync("http://localhost:5130/" + url, data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse?> Delete<TResponse>(string url, Guid id)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"http://localhost:5130/{url}/{id}"
            );

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

    }
}
