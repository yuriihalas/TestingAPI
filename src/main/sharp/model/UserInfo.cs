using System.Text.Json.Serialization;

namespace TestingApi.Main.Sharp.Model;

public class UserInfo
{
    [JsonPropertyName("data")]
    public User User { get; set; }
    
    [JsonPropertyName("support")]
    public Support Support { get; set; }

    public override string ToString()
    {
        return $"{nameof(User)}: {User}, {nameof(Support)}: {Support}";
    }
}