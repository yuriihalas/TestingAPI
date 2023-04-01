using System.Text.Json.Serialization;

namespace TestingApi.Main.Sharp.Model;

public class Employee
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("job")]
    public string Job { get; set; }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }    

    [JsonPropertyName("updatedAt")]
    public string UpdatedAt { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Job)}: {Job}, {nameof(Id)}: {Id}, {nameof(CreatedAt)}: {CreatedAt}, {nameof(UpdatedAt)}: {UpdatedAt}";
    }
}