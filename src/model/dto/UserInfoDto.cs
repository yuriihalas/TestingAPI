namespace TestingApi.dto;

public class UserInfoDto
{
    public UserDto data { get; set; }
    public SupportDto support { get; set; }

    public override string ToString()
    {
        return $"{nameof(data)}: {data}, {nameof(support)}: {support}";
    }
}