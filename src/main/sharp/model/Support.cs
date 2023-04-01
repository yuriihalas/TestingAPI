using System.Text.Json.Serialization;

namespace TestingApi.Main.Sharp.Model;

public class Support
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; }

    public override string ToString()
    {
        return $"{nameof(Url)}: {Url}, {nameof(Text)}: {Text}";
    }
}