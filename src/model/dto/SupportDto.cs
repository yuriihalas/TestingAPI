namespace TestingApi.dto;

public class SupportDto
{
    public string url { get; set; }
    public string text { get; set; }

    public override string ToString()
    {
        return $"{nameof(url)}: {url}, {nameof(text)}: {text}";
    }
}