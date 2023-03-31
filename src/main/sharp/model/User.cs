using System.Text.Json.Serialization;

namespace TestingApi.dto;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("avatar")]
    public string Avatar { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Email)}: {Email}, {nameof(FirstName)}: " +
               $"{FirstName}, {nameof(LastName)}: {LastName}, {nameof(Avatar)}: {Avatar}";
    }
}