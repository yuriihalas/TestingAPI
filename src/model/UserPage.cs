namespace TestingApi.dto;

public class UserPage
{
    public int PageNumber { get; set; }
    public int ResultsPerPage { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }
    public List<User> Users { get; set; }
    public Support Support { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(PageNumber)}: {PageNumber}, {nameof(ResultsPerPage)}: {ResultsPerPage}, {nameof(Total)}: {Total}, " +
            $"{nameof(TotalPages)}: {TotalPages}, {nameof(Users)}: {string.Join(", ", Users)}, {nameof(Support)}: {Support}";
    }
}