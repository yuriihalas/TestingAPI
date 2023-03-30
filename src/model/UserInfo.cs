namespace TestingApi.dto;

public class UserInfo
{
    public User User { get; set; }
    public Support Support { get; set; }

    public override string ToString()
    {
        return $"{nameof(User)}: {User}, {nameof(Support)}: {Support}";
    }
}