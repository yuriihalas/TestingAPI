using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestingApi;

public static class JsonUtils
{
    private static readonly JsonSerializerOptions? JsonSerializerOptions;

    static JsonUtils()
    {
        JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    public static StringContent Serialize(object obj)
    {
        var json = JsonSerializer.Serialize(obj, JsonSerializerOptions);
        return new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
    }

    public static async Task<TV> GetModel<TV>(HttpResponseMessage message)
    {
        var stream = await message.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<TV>(stream, JsonSerializerOptions) ??
               throw new InvalidOperationException();
    }
}