namespace TestingApi.dto;

public class Support
{
    public string Url { get; set; }
    public string Text { get; set; }

    public override string ToString()
    {
        return $"{nameof(Url)}: {Url}, {nameof(Text)}: {Text}";
    }
}