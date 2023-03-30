using System.Text.Json;
using AutoMapper;
using TestingApi.dto.profiles;

namespace TestingApi;

public class Mapper
{
    private readonly JsonSerializerOptions? _jsonSerializerOptions;
    private readonly IMapper _mapper;

    public Mapper()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<SupportProfile>();
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<UserPageProfile>();
            cfg.AddProfile<UserInfoProfile>();
        });
        _mapper = configuration.CreateMapper();

        _jsonSerializerOptions = new JsonSerializerOptions();
        _jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        _jsonSerializerOptions.IgnoreNullValues = true;
    }

    public async Task<V> getModel<T, V>(HttpResponseMessage message)
    {
        var responseStream = await message.Content.ReadAsStreamAsync();
        var modelDto = await JsonSerializer.DeserializeAsync<T>(responseStream, _jsonSerializerOptions);
        return _mapper.Map<V>(modelDto);
    }
}