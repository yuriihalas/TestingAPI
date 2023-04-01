using System.Text.Json.Serialization;

namespace TestingApi.Main.Sharp.Model;

public class Account
{
    [JsonPropertyName("email")]
    public string Name { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
}