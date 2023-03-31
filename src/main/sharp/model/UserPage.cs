using System.Text.Json.Serialization;

namespace TestingApi.dto;

public class UserPage
{
    [JsonPropertyName("page")]
    public int PageNumber { get; set; }
    
    [JsonPropertyName("per_page")]
    public int ResultsPerPage { get; set; }
    
    [JsonPropertyName("total")]
    public int Total { get; set; }
    
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("data")]
    public List<User> Users { get; set; }

    [JsonPropertyName("support")]
    public Support Support { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(PageNumber)}: {PageNumber}, {nameof(ResultsPerPage)}: {ResultsPerPage}, {nameof(Total)}: {Total}, " +
            $"{nameof(TotalPages)}: {TotalPages}, {nameof(Users)}: {string.Join(", ", Users)}, {nameof(Support)}: {Support}";
    }
}