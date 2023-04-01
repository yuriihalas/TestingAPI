using TestingApi.Main.Sharp.Model;

namespace TestingApi.Main.Sharp;

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

    public async Task<HttpResponseMessage> PostUserAsync(Employee employee)
    {
        var content = JsonUtils.Serialize(employee);
        return await _httpClient.PostAsync("api/users", content);
    }

    public async Task<HttpResponseMessage> UpdateUserAsync(Employee employee, int id)
    {
        var content = JsonUtils.Serialize(employee);
        return await _httpClient.PutAsync($"api/users/{id}", content);
    }

    public async Task<HttpResponseMessage> PatchUserAsync(Employee employee, int id)
    {
        var content = JsonUtils.Serialize(employee);
        return await _httpClient.PatchAsync($"api/users/{id}", content);
    }

    public async Task<HttpResponseMessage> DeleteUserAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/users/{id}");
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}