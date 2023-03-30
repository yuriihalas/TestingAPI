using System.Net.Http.Headers;
using System.Net.Mime;

namespace TestingApi;

public class ApiClient : IDisposable
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ResourceUtils.AppSettings["baseUrl"]);
    }

    public async Task<HttpResponseMessage> GetAllUsersAsync(int page)
    {
        return await _httpClient.GetAsync($"api/users?page={page}");
    }

    public async Task<HttpResponseMessage> GetUserAsync(int id)
    {
        return await _httpClient.GetAsync($"api/users/{id}");
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

}